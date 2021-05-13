using Microsoft.Extensions.DependencyInjection;
using TaskNote.Configuration;
using TaskNote.WpfConfigurationManager;
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
                services
                    .AddSingleton<IFileInfoFacade, PackageFileInfoFacade>()
                    .AddSingleton<IVersion, PackageVersion>()
                    .AddSingleton<IUserConfiguration, WpfManagerUserConfiguration>()
                    .AddSingleton<ILoggingBatch, PackageLoggingBatch>()
                    .AddSingleton<IConfigurationBatch, PackageConfigurationBatch>()
                    ;
            }
            else
            {
                services
                    .AddSingleton<IFileInfoFacade, StorageFileInfo>()
                    .AddSingleton<IVersion, AssemblyVersion>()
                    .AddSingleton<IUserConfiguration, PackageUserConfiguration>()
                    .AddSingleton<ILoggingBatch, LoggingBatch>()
                    .AddSingleton<IConfigurationBatch, ConfigurationBatch>()
                    ;
            }
            return services;
        }
    }
}
