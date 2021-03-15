using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using NLog.Extensions.Logging;
using System.IO;
using TaskNote.Storage;
using TaskNote.Configuration;

namespace TaskNote.Logging
{
    public static class LoggingServicesCollectionExtensions
    {
        // ここのクラスはBuildServiceProviderを使っているので、Microsoft.Extensions.DependencyInjection.Abstractionが必要
        // クラス名をBuilderにしたほうがいいかも

        public static IServiceCollection AddNLog(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            // ディレクトリの生成
            provider.GetService<IStorageDirectory>().Initialization();
            var fileInfo = provider.GetService<IStorageFileInfo>();

            // NLogのファイルコピー
            if (!fileInfo.NLog.Exists)
            {
                if (!fileInfo.DefualtNLog.Exists) throw new FileNotFoundException(fileInfo.DefualtNLog.PhysicalPath);
                File.Copy(fileInfo.DefualtNLog.PhysicalPath, fileInfo.NLog.PhysicalPath);
            }

            // Configurationのファイルコピー
            provider = services.AddConfiguration(fileInfo.AppSetting, fileInfo.DefualtAppSetting).BuildServiceProvider();

            // TODO:ログの出力ディレクトリが設定できずにいる

            return services
                .AddLogging(_ => _
                    .ClearProviders()
                    .AddNLog(fileInfo.NLog.PhysicalPath)
                    .AddConfiguration(provider.GetService<IConfiguration>().GetSection("Logging")))
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddSingleton<ILogger>(_ => _.GetService<ILoggerFactory>().CreateLogger(""));
                ;
        }

        /*
        public static IServiceCollection AddNLog(this IServiceCollection services)
        {
            new Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo(new FileInfo(""));
            var config = new LoggingConfiguration();
            services.AddSingleton<ILoggerOptions>();
            services.AddSingleton(config);

            var provider = services.BuildServiceProvider();
            var loggingSection = provider.GetService<IConfiguration>().GetSection("Logging");

            // NLog
            var options = new NLogProviderOptions();
            string layout = "${time} ${uppercase:${level}} ${logger} ${message} ${exception}";

            // ログファイル生成
            config.AddTarget(new FileTarget(nameof(FileTarget))
            {
                FileName = Path.Combine(),
                Layout = layout
            });
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, nameof(FileTarget));

            // デバッグ出力
            config.AddTarget(nameof(OutputDebugStringTarget), new OutputDebugStringTarget()
            {
                Layout = layout
            });
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, nameof(FileTarget));

            services.AddLogging(_ => _.ClearProviders().AddNLog(config, options).AddConfiguration(loggingSection));

            var builder = new ConfigurationBuilder().SetBasePath("");


            return services;
        }*/
    }
}
