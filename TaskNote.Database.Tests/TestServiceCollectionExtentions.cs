using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Database.Tests
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection AddTest(this IServiceCollection services, string database)
        {
#if DEBUG
            services.AddDatabase<EntityFramework.InMemory.InMemoryDatabaseServices>();
#else
            services.AddDatabase<EntityFramework.DbSqlite.SqliteDatabaseServices>();
#endif
            return services;
        }
    }
}
