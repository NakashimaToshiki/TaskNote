using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Storage
{
    public static class StorageCollectionExtensions
    {
        public static IServiceCollection AddStorage<TStorageServices>(this IServiceCollection services) where TStorageServices : IStorageServices
        {
            var databaseServices = (TStorageServices)Activator.CreateInstance(typeof(TStorageServices));
            databaseServices.Configure(services);
            return services;
        }
    }
}
