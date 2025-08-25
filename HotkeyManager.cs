using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHotkey;

namespace WindowDesktopSwitcher
{
    class HotkeyManager
    {
        Dictionary<string, AppConfig> mappings;

        public void RegisterHotkeys(Dictionary<string, AppConfig> mappings)
        {
            this.mappings = mappings;
            if (mappings == null) return;

            foreach (var mapping in mappings)
            {
                if (Enum.TryParse(mapping.Key, true, out Keys keys))
                {
                    NHotkey.WindowsForms.HotkeyManager.Current.AddOrReplace(mapping.Key, keys, OnHotkeyPressed);
                }
            }
        }

        void OnHotkeyPressed(object sender, HotkeyEventArgs e)
        {
            var config = mappings[e.Name];

            MessageBox.Show($"Hotkey '{e.Name}' pressed! \nSwitching to Desktop {config.Desktop} \nRunning: {config.Exe}");

            e.Handled = true;
        }
    }
}
