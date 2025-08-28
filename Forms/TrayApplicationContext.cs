using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;
using NHotkey.WindowsForms;
using WindowDesktopSwitcher.Managers;
using HotkeyManager = WindowDesktopSwitcher.Managers.HotkeyManager;


namespace WindowDesktopSwitcher.Forms
{
    public class TrayApplicationContext : ApplicationContext
    {
        NotifyIcon trayIcon;
        ConfigManager configManager = new ConfigManager();
        HotkeyManager hotkeyManager = new HotkeyManager();
        HotkeyManagerForm? settingsForm;
        public TrayApplicationContext()
        {
            string iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "WindowDesktopSwitcher.ico");

            trayIcon = new NotifyIcon()
            {
                Icon = new Icon(iconPath),
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items = {
                        new ToolStripMenuItem("Settings", null, ShowSettings),
                        new ToolStripMenuItem("Exit", null, Exit)
                    }
                },
                Visible = true
            };

            ReloadHotkeys();
        }

        public void ReloadHotkeys()
        {
            hotkeyManager.UnregisterAll();
            var mappings = configManager.LoadConfig();
            if (mappings != null)
            {
                hotkeyManager.RegisterHotkeys(mappings);
            }
        }

        void Exit(object sender, EventArgs e)
        {
            hotkeyManager.UnregisterAll();
            trayIcon.Visible = false;
            Application.Exit();
        }

        void ShowSettings(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                settingsForm = new HotkeyManagerForm(this);
                settingsForm.Show();
            }
            else settingsForm.BringToFront();
        }
    }
}
