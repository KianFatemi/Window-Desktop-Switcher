using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowDesktopSwitcher.Forms;
using WindowDesktopSwitcher.Managers;
using WindowDesktopSwitcher.Models;
using Microsoft.Win32;
using System.Diagnostics;

namespace WindowDesktopSwitcher
{
    public partial class HotkeyManagerForm : Form
    {
        ConfigManager configManager = new ConfigManager();
        Dictionary<string, AppConfig> mappings;
        TrayApplicationContext mainContext;

        const string AppName = "WindowDesktopSwitcher";
        static readonly string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public HotkeyManagerForm(TrayApplicationContext context)
        {
            InitializeComponent();
            mainContext = context;

        }

        private void HotkeyManagerForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadMappings();

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, false))
            {
                var isEnabled = key.GetValue(AppName) != null;
                chkStartup.Checked = isEnabled;
            }
        }

        void SetupDataGridView()
        {
            dgvMappings.Columns.Clear();
            dgvMappings.AutoGenerateColumns = false;
            dgvMappings.Columns.Add("Hotkey", "Hotkey");
            dgvMappings.Columns.Add("Desktop", "Desktop");
            dgvMappings.Columns.Add("Application", "Application");
            dgvMappings.Columns["Application"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void LoadMappings()
        {
            mappings = configManager.LoadConfig() ?? new Dictionary<string, AppConfig>();
            RefreshGrid();

        }

        void RefreshGrid()
        {
            dgvMappings.Rows.Clear();
            foreach (var mapping in mappings)
            {
                string exePath = mapping.Value.Exe;
                string displayName = Path.GetFileName(exePath);

                try
                {
                    if (File.Exists(exePath))
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(exePath);
                        if (!string.IsNullOrEmpty(versionInfo.FileDescription))
                        {
                            displayName = versionInfo.FileDescription;
                        }
                    }
                }
                catch
                {
                    string appName = Path.GetFileName(mapping.Value.Exe);
                    dgvMappings.Rows.Add(mapping.Key, mapping.Value.Desktop, $"{appName} ({mapping.Value.Exe})");
                }
                dgvMappings.Rows.Add(mapping.Key, mapping.Value.Desktop, $"{displayName} ({exePath})");

            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new EditMappingForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string keyName = new KeysConverter().ConvertToString(dialog.Hotkey);
                    mappings[keyName] = new AppConfig { Desktop = dialog.DesktopNumber, Exe = dialog.ApplicationPath };
                    SaveChangesAndReload();
                }
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMappings.SelectedRows.Count == 0) return;

            string selectedKey = dgvMappings.SelectedRows[0].Cells["Hotkey"].Value.ToString();
            var currentConfig = mappings[selectedKey];

            Enum.TryParse(selectedKey, out Keys hotkey);

            using (var dialog = new EditMappingForm(hotkey, currentConfig.Desktop, currentConfig.Exe))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    mappings.Remove(selectedKey);
                    string newKeyName = new KeysConverter().ConvertToInvariantString(dialog.Hotkey);
                    mappings[newKeyName] = new AppConfig { Desktop = dialog.DesktopNumber, Exe = dialog.ApplicationPath };
                    SaveChangesAndReload();
                }
            }
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvMappings.SelectedRows.Count == 0) return;

            string selectedKey = dgvMappings.SelectedRows[0].Cells["Hotkey"].Value.ToString();
            var result = MessageBox.Show($"Are you sure you want to remove the mapping for '{selectedKey}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                mappings.Remove(selectedKey);
                SaveChangesAndReload();
            }
        }

        void SaveChangesAndReload()
        {
            configManager.SaveConfig(mappings);
            RefreshGrid();
            mainContext?.ReloadHotkeys();
        }

        void SetStartup(bool isChecked)
        {
            try
            {
                using(RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true))
                {
                    if (isChecked)
                    {
                        key.SetValue(AppName, Application.ExecutablePath);
                    }
                    else
                    {
                        key.DeleteValue(AppName, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving startup setting: {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup(chkStartup.Checked);
        }
    }
}
