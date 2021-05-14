using Microsoft.Extensions.DependencyInjection;
using TaskNote.Configuration;
using TaskNote.Logging;
using Moq;

namespace TaskNote
{
    public static class OptionsTestServiceCollectionExtentions
    {

        public static IServiceCollection UseTestOptions(this IServiceCollection services, TestOptions options)
        {
            NLog.GlobalDiagnosticsContext.Set("TestName", options.Name);

            // Options注入
            services
                .AddSingleton(options)
                .AddSingleton<StopwatchDatetimeOptions>()
                .AddSingleton<IDateTimeOptions>(_ => _.GetRequiredService<StopwatchDatetimeOptions>())
                .AddSingleton<IFileInfoFacade, TestFileInfoFacade>()
                .AddSingleton<DummyVersion>()
                .AddSingleton<IVersion>(_ => _.GetRequiredService<DummyVersion>())
                .AddSingleton<IUserConfiguration>(new Mock<IUserConfiguration>().Object)
                .AddSingleton<IConfigurationBatch, ConfigurationBatch>()
                .AddSingleton<ILoggingBatch, LoggingBatch>()
                ;
#if MOCK
            services.AddMockDatetimeOptions();
#else
            services.AddStopwatchDatetimeOptions(System.DateTime.MinValue);
#endif


            // 設定ファイルの読み込み
            services.AddSingleton(services.BuildServiceProvider().GetService<IConfigurationBatch>().GetConfiguration());

            // NLogファイルの読み込み
            services.AddTaskNoteLogging(services.BuildServiceProvider().GetService<ILoggingBatch>().GetOptions());

            return services;
        }
    }
}
