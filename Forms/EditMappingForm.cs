using System;
using System.Windows.Forms;

namespace WindowDesktopSwitcher
{
    public partial class EditMappingForm : Form
    {
        public Keys Hotkey { get; private set; }
        public int DesktopNumber { get; private set; }
        public string ApplicationPath { get; private set; }

        public EditMappingForm()
        {
            InitializeComponent();
        }

        public EditMappingForm(Keys hotkey, int desktop, string appPath)
        {
            InitializeComponent();

            Hotkey = hotkey;
            DesktopNumber = desktop;
            ApplicationPath = appPath;

            txtHotkey.Text = new KeysConverter().ConvertToString(hotkey);
            numDesktop.Value = desktop;
            txtAppPath.Text = appPath;
        }

        void btnRecord_Click(object sender, EventArgs e)
        {
            txtHotkey.Text = "Press a key...";
            txtHotkey.Focus();
        }

        void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu
                || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                return;
            }

            Keys fullHotkey = e.KeyCode | e.Modifiers;
            Hotkey = fullHotkey;
            txtHotkey.Text = new KeysConverter().ConvertToString(fullHotkey);
        }

        void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Executable Files (*.exe)|*.exe|All files (*.*)|*.*";
                dialog.Title = "Select an Application";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtAppPath.Text = dialog.FileName;
                }
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (Hotkey == Keys.None || string.IsNullOrWhiteSpace(txtAppPath.Text))
            {
                MessageBox.Show("Please record a hotkey and select an application path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            DesktopNumber = (int)numDesktop.Value;
            ApplicationPath = txtAppPath.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}