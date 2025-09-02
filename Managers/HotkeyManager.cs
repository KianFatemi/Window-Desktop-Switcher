using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHotkey;
using WindowDesktopSwitcher.Models;
using WindowDesktopSwitcher.Services;

namespace WindowDesktopSwitcher.Managers
{
    class HotkeyManager
    {
        Dictionary<string, AppConfig> mappings;
        DesktopManager desktopManager = new DesktopManager();
        AppManager appManager = new AppManager();

        public void RegisterHotkeys(Dictionary<string, AppConfig> mappings)
        {
            this.mappings = mappings;
            if (mappings == null) return;

            var converter = new KeysConverter();

            foreach (var mapping in mappings)
            {
                try
                {
                    Keys keys = (Keys)converter.ConvertFromString(mapping.Key);
                    NHotkey.WindowsForms.HotkeyManager.Current.AddOrReplace(mapping.Key, keys, OnHotkeyPressed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not parse hotkey '{mapping.Key}': {ex.Message}");

                }
            }
        }

        void OnHotkeyPressed(object sender, HotkeyEventArgs e)
        {
            var config = mappings[e.Name];

            desktopManager.SwitchDesktops(config.Desktop);

            Thread.Sleep(150);

            appManager.FocusOrLaunch(config.Exe);

            e.Handled = true;
        }

        public void UnregisterAll()
        {
            if (mappings == null) return;

            foreach (var mapping in mappings)
            {
                NHotkey.WindowsForms.HotkeyManager.Current.Remove(mapping.Key);
            }
        }
    }
}
