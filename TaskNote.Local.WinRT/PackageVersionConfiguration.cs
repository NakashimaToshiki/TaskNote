using System;
using TaskNote.Configuration;
using Windows.Storage;

namespace TaskNote.WinRT
{
    public class PackageVersionConfiguration : IVersionConfiguration
    {
        static readonly private string configKey = "version";

        public string Load()
        {
            try
            {
                var settings = ApplicationData.Current.LocalSettings;
                return settings.Values[configKey] as string;
            }
            catch (Exception e)
            {
                throw new ConfigurationException(e);
            }
        }

        public void Save(string versionName)
        {
            try
            {
                var settings = ApplicationData.Current.LocalSettings;

                settings.Values[configKey] = versionName;
            }
            catch (Exception e)
            {
                throw new ConfigurationException(e);
            }
        }
    }
}
