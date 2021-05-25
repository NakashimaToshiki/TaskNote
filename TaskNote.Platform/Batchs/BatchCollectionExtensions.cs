﻿using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Platform.Batchs
{
    public static class BatchCollectionExtensions
    {
        public static IServiceCollection AddPlatformBatch(this IServiceCollection services) =>
            services
                .AddSingleton<MainStartBatch>()
                .AddSingleton<MainExitBatch>()
                .AddSingleton<MainWindowStartBatch>()
                .AddSingleton<IStartBatch>(_ => _.GetService<MainStartBatch>())
                .AddSingleton<IExitBatch>(_ => _.GetService<MainExitBatch>());
    }
}