using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using NLog.Extensions.Logging;
using TaskNote.Configuration;

namespace TaskNote.Logging
{

    public static class LoggingServicesCollectionExtensions
    {
        public static IServiceCollection AddTaskNoteLogging(this IServiceCollection services, LoggingOptions loggingBatch)
        {
            // ${LogPath}を置き換え
            NLog.GlobalDiagnosticsContext.Set("LogPath", loggingBatch.LogFolder + "\\");

            // こっちの方法だとパッケージ版だと動かない
            //NLog.LogManager.Configuration.Variables.Add("LogPath", loggingBatch.LogFolder + "\\");

            services
                .AddLogging(_ => _
                    .ClearProviders()
                    .AddNLog(loggingBatch.FilePath)
                    .AddConfiguration(loggingBatch.Configuration)
                    )
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddSingleton<ILogger>(_ => _.GetService<ILoggerFactory>().CreateLogger(""));
            ;

            return services;
        }
    }
}
