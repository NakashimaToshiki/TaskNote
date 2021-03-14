using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Database
{
    public static class DatabaseCollectionExtensions
    {
        public static IServiceCollection AddDatabase<TDatabaseServices> (this IServiceCollection services) where TDatabaseServices : IDatabaseServices
        {
            var databaseServices = (TDatabaseServices)Activator.CreateInstance(typeof(TDatabaseServices));
            databaseServices.ConfigureDatabaseServices(services);
            return services;
        }
    }
}
