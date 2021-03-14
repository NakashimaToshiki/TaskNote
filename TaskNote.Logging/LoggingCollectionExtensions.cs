using Microsoft.Extensions.DependencyInjection;
using NLog.Config;
using NLog.Extensions.Logging;
using System;

namespace TaskNote.Logging
{
    public static class LoggingCollectionExtensions
    {
        public static IServiceCollection AddNLog(this IServiceCollection services)
        {
            var config = new LoggingConfiguration();
            services.AddSingleton(config);

            // NLog
            var options = new NLogProviderOptions();
            string layout = "${time} ${uppercase:${level} ${logger} ${message} ${exception}";

            return services;
        }
    }
}
