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

        public bool Load()
        {
            try
            {
                var settings = ApplicationData.Current.LocalSettings;
                bool ret = true;
                if (settings.Values.TryGetValue(nameof(_options.UserId), out var userId)) _options.UserId = userId as string;
                else ret = false;
                if (settings.Values.TryGetValue(nameof(_options.Password), out var password)) _options.Password = password as string;
                else ret = false;
                return ret;
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
