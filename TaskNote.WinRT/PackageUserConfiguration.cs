using System;
using TaskNote.Configuration;
using Windows.Storage;

namespace TaskNote.WinRT
{
    public class PackageUserConfiguration : IUserConfiguration
    {
        private readonly UserOptions _options;

        public PackageUserConfiguration(UserOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Load()
        {
            try
            {
                var settings = ApplicationData.Current.LocalSettings;
                _options.UserId = settings.Values[nameof(_options.UserId)] as string;
                _options.Password = settings.Values[nameof(_options.Password)] as string;
            }
            catch (Exception e)
            {
                throw new Configuration.ConfigurationException(e);
            }
        }

        public void Save()
        {
            try
            {
                var settings = ApplicationData.Current.LocalSettings;

                settings.Values[nameof(_options.UserId)] = _options.UserId;
                settings.Values[nameof(_options.Password)] = _options.Password;
            }
            catch (Exception e)
            {
                throw new Configuration.ConfigurationException(e);
            }
        }
    }
}
