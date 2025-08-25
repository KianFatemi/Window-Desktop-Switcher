using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowDesktopSwitcher
{
    class ConfigManager
    {
        private const string ConfigFileName = "config.json";

        public Dictionary<string, AppConfig> LoadConfig()
        {
            try
            {
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
                var jsonText = File.ReadAllText(configFile);
                return JsonConvert.DeserializeObject<Dictionary<string, AppConfig>>(jsonText);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
