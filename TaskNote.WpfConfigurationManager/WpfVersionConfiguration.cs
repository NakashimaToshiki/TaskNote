using System;
using System.Configuration;
using TaskNote.Configuration;

namespace TaskNote.WpfConfigurationManager
{
    public class WpfVersionConfiguration : IVersionConfiguration
    {
        static readonly private string configKey = "version";

        public string Load()
        {
            try
            {
                return ConfigurationManager.AppSettings[configKey];
            }
            catch (Exception e)
            {
                throw new Configuration.ConfigurationException(e);
            }
        }

        public void Save(string versionName)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                settings.Remove(configKey);
                settings.Add(configKey, versionName);

                configFile.Save();
            }
            catch (Exception e)
            {
                throw new Configuration.ConfigurationException(e);
            }
        }
    }
}
