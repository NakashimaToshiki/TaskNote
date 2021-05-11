using System;
using System.Configuration;

namespace TaskNote.Configuration.Desktop
{
    public class ConfigurationManagerUserInfo : IConfigurationUserInfo
    {
        private readonly UserOptions _options;

        public ConfigurationManagerUserInfo(UserOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Load()
        {
            var settings = ConfigurationManager.AppSettings;
            _options.Password = settings[nameof(_options.Password)];
            _options.UserId = settings[nameof(_options.UserId)];
        }

        public void Save()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings.Remove(nameof(_options.Password));
            settings.Remove(nameof(_options.UserId));

            settings.Add(nameof(_options.Password), _options.Password);
            settings.Add(nameof(_options.UserId), _options.UserId);

            configFile.Save();
        }
    }
}
