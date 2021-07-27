using Microsoft.Extensions.DependencyInjection;
using TaskNote.Configuration;
using TaskNote.WpfConfigurationManager;
using Windows.ApplicationModel;

namespace TaskNote.WinRT
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

        public static IServiceCollection AddDesktopOrPackageOptions(this IServiceCollection services)
        {
            services.AddOptions();
#if MOCK
            services.AddMockDatetimeOptions();
#else
            services.AddSingleton<IDateTimeOptions, DateTimeOptions>();
#endif

            if (IsPackege)
            {
                services
                    .AddSingleton<IFileInfoFacade, PackageFileInfoFacade>()
                    .AddSingleton<IVersion, PackageVersion>()
                    .AddSingleton<IVersionConfiguration, WpfVersionConfiguration>()
                    .AddSingleton<IUserConfiguration, WpfManagerUserConfiguration>()
                    .AddSingleton<ILoggingBatch, PackageLoggingBatch>()
                    .AddSingleton<IConfigurationBatch, PackageConfigurationBatch>()
                    ;
            }
            else
            {
                services
                    .AddSingleton<IFileInfoFacade, FileInfoFacade>()
                    .AddSingleton<IVersion, AssemblyVersion>()
                    .AddSingleton<IVersionConfiguration, PackageVersionConfiguration>()
                    .AddSingleton<IUserConfiguration, PackageUserConfiguration>()
                    .AddSingleton<ILoggingBatch, LoggingBatch>()
                    .AddSingleton<IConfigurationBatch, ConfigurationBatch>()
                    ;
            }
            return services;
        }
    }
}
