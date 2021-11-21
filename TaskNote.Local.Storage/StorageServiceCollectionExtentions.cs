using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Storage
{
    public static class StorageServiceCollectionExtentions
    {
        public static IServiceCollection AddStorage<TServices>(this IServiceCollection services) where TServices : IStorageServices
        {
            var instance = (TServices)Activator.CreateInstance(typeof(TServices));
            instance.Configure(services);
            return services;
        }
    }
}
