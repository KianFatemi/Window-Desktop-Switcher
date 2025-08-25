using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;

namespace WindowDesktopSwitcher
{
    class TrayApplicationContext : ApplicationContext
    {
        NotifyIcon trayIcon;
        ConfigManager configManager = new ConfigManager();
        HotkeyManager hotkeyManager = new HotkeyManager();

        public TrayApplicationContext()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = System.Drawing.SystemIcons.Application,
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items = { new ToolStripMenuItem("Exit", null, Exit) }
                },
                Visible = true
            };

            LoadAndRegister();
        }

        void LoadAndRegister()
        {
            var mappings = configManager.LoadConfig();
            if (mappings != null)
            {
                hotkeyManager.RegisterHotkeys(mappings);
            }
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
