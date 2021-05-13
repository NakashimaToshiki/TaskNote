using System;
using TaskNote.Configuration;
using Windows.Storage;

namespace TaskNote.Installer
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
            var settings = ApplicationData.Current.LocalSettings;
            _options.UserId = settings.Values[nameof(_options.UserId)] as string;
            _options.Password = settings.Values[nameof(_options.Password)] as string;
        }

        public void Save()
        {
            var settings = ApplicationData.Current.LocalSettings;

            settings.Values[nameof(_options.UserId)] = _options.UserId;
            settings.Values[nameof(_options.Password)] = _options.Password;
        }
    }
}
