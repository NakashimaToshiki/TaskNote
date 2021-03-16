using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Database
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase<TDatabaseServices> (this IServiceCollection services) where TDatabaseServices : IDatabaseServices
        {
            var instance = (TDatabaseServices)Activator.CreateInstance(typeof(TDatabaseServices));
            instance.Configure(services);
            return services;
        }
    }
}
