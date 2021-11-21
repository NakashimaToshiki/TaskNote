using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Models.Repositoris;
using TaskNote.Models.TaskModels;

namespace TaskNote.Models
{
    public static class ModelServiceCollectionExtentions
    {
        public static IServiceCollection AddModel(this IServiceCollection services) =>
            services
            .AddSingleton<System.Threading.CancellationTokenSource>()
            .AddSingleton<StorageMigrateRepository>()
            .AddSingleton<TaskItemRepository>()
            .AddSingleton<VerficationRepository>()
            .AddSingleton<UploadTraceLogRepository>()
            .AddSingleton<TaskModelCreater>()

            ;
    }
}
