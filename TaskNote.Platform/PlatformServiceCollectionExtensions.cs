using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using TaskNote.Models;
using TaskNote.Platform.Batchs;

namespace TaskNote.Platform
{
    public static class PlatformServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatform<TPlatformServices>(this IServiceCollection services, SynchronizationContext synchronization) where TPlatformServices : IPlatformServices
        {
            services
                .AddSingleton(synchronization)
                .AddSingleton<UserInfoViewModel>()
                .AddModel()
                .AddPlatformBatch()
                ;

            var instance = (TPlatformServices)Activator.CreateInstance(typeof(TPlatformServices));
            instance.ConfigureServices(services);
            return services;
        }
    }
}
