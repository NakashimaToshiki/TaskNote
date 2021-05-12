using Microsoft.Extensions.DependencyInjection;
using TaskNote.Configuration;
using TaskNote.Logging;

namespace TaskNote
{
    public static class OptionsTestServiceCollectionExtentions
    {

        public static IServiceCollection UseTestOptions(this IServiceCollection services, TestOptions options)
        {
            NLog.GlobalDiagnosticsContext.Set("TestName", options.Name);

            services.AddSingleton(options);
            services
                .AddSingleton<IFileInfoFacade, TestFileInfoFacade>();

            // 設定ファイルの読み込み
            services.AddSingleton<IConfigurationBatch, ConfigurationBatch>();
            services.AddSingleton(services.BuildServiceProvider().GetService<IConfigurationBatch>().GetConfiguration());

            // NLogファイルの読み込み
            services.AddSingleton<ILoggingBatch, LoggingBatch>();
            services.AddTaskNoteLogging(services.BuildServiceProvider().GetService<ILoggingBatch>().GetOptions());

            // Storageが少ないのでここで記述している
            services.AddSingleton<Storage.CreateDirectory>();
            services.BuildServiceProvider().GetService<Storage.CreateDirectory>().Create();

            services
                .AddSingleton<StopwatchDatetimeOptions>()
                .AddSingleton<IDateTimeOptions>(_ => _.GetRequiredService<StopwatchDatetimeOptions>())
                .AddSingleton<DummyVersion>()
                .AddSingleton<IVersion>(_ => _.GetRequiredService<DummyVersion>())
                ;

            return services;
        }
    }
}
