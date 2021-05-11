using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity.Tests
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection AddTest(this IServiceCollection services, string database)
        {
#if DEBUG
            services.AddDatabase<Entity.FrameworkCore.InMemory.InMemoryDatabaseServices>();
#else
            services.AddDatabase<Entity.FrameworkCore.DbSqlite.SqliteDatabaseServices>();
#endif
            return services;
        }
    }
}
