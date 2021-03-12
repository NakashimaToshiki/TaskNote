using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Database
{
    public static class DatabaseCollectionExtensions
    {
        // EnittyFrameworkではこっちのやり方もあるけど、保留
        /*
        public static void ConfigureDatabaseServices(this IServiceCollection services, Type databaseServicesType)
        {
            if (databaseServicesType is null)
            {
                throw new ArgumentNullException(nameof(databaseServicesType));
            }

            var databaseServices = (IDatabaseServices)Activator.CreateInstance(databaseServicesType);
            databaseServices.ConfigureDatabaseServices(services);
        }*/

        public static void AddDatabase<TDatabaseServices> (this IServiceCollection services) where TDatabaseServices : IDatabaseServices
        {
            var databaseServices = (TDatabaseServices)Activator.CreateInstance(typeof(TDatabaseServices));
            databaseServices.ConfigureDatabaseServices(services);
        }
    }
}
