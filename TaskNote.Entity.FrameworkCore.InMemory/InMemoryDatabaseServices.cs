using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public class InMemoryDatabaseServices : BaseDatabaseServices<TaskNoteInMemoryContext>
    {
        public override void Configure(IServiceCollection services)
        {
            services
                .AddSingleton<IMigrate, SpyMigrate>();

            base.Configure(services);
        }
    }
}
