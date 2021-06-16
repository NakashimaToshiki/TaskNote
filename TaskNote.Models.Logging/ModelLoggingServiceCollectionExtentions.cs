using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TaskNote.Logging;
using TaskNote.Models.Repositoris;

namespace TaskNote.Models.Logging
{
    public static class ModelLoggingServiceCollectionExtentions
    {
        public static IServiceCollection AddLogging(this IServiceCollection services, LoggingOptions options)
        {
            services.AddTaskNoteLogging(options);

            //　必要があればここでクラスごとでログの取得方法を変更する

            return services;
        }
    }
}
