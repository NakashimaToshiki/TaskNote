using Microsoft.Extensions.DependencyInjection;
using TaskNote.Configuration;
using Windows.ApplicationModel;

namespace TaskNote.Installer
{
    public static class PackageServiceCollectionExtentions
    {
        /// <summary>
        /// パッケージ版であるかの有無を取得します
        /// </summary>
        private static bool IsPackege
        {
            get
            {
                try
                {
                    var _ = Package.Current.Id;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static IServiceCollection AddDesktopOrPackage(this IServiceCollection services)
        {
            if (IsPackege)
            {
                services.AddSingleton<IVersion, PackageVersion>();
                services.AddSingleton<IFileInfoFacade, PackageFileInfoFacade>();
                services.AddSingleton<ILoggingBatch, PackageLoggingBatch>();
                services.AddSingleton<IConfigurationBatch, PackageConfigurationBatch>();
            }
            else
            {
                services.AddSingleton<IVersion, AssemblyVersion>();
                services.AddSingleton<IFileInfoFacade, StorageFileInfo>();
                services.AddSingleton<ILoggingBatch, LoggingBatch>();
                services.AddSingleton<IConfigurationBatch, ConfigurationBatch>();
            }
            return services;
        }
    }
}
