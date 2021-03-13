using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Platform
{
    public static class PlatformServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatform<TPlatformServices>(this IServiceCollection services) where TPlatformServices : IPlatformServices
        {
            var instance = (TPlatformServices)Activator.CreateInstance(typeof(TPlatformServices));
            instance.ConfigureServices(services);
            return services;
        }
    }
}
