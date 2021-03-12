using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Database.EntityFramework.InMemory
{
    public class InMemoryDatabaseServices : BaseDatabaseServices<TaskNoteInMemoryContext>
    {
        public override void ConfigureDatabaseServices(IServiceCollection services)
        {
            services
                .AddSingleton<IMigrate, SpyMigrate>()
                .AddSingleton<DatabaseOptions>()
                .AddSingleton<IDatabaseOptions>(_ => _.GetService<DatabaseOptions>());

            base.ConfigureDatabaseServices(services);
        }
    }
}
