using Microsoft.Extensions.DependencyInjection;
using TaskNote.Configuration;
using TaskNote.Storage;
using TaskNote.Storage.Packege;
using Windows.ApplicationModel;

namespace TaskNote.Logging.Installer
{
    // TODO:プロジェクト名を変えるかどうか悩んでいる

    public static class LoggingServiceCollectionExtentions
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
                services.AddSingleton<IFileInfoFacade, PackegeFileInfoFacade>();
                services.AddSingleton<ILoggingBatch, PackageLoggingBatch>();
                services.AddSingleton<IConfigurationBatch, PackageConfigurationBatch>();
            }
            else
            {
                services.AddSingleton<IFileInfoFacade, StorageFileInfo>();
                services.AddSingleton<ILoggingBatch, LoggingBatch>();
                services.AddSingleton<IConfigurationBatch, ConfigurationBatch>();
            }
            return services;
        }
    }
}
