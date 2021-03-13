using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskNote.Database.TaskItems;

namespace TaskNote.Database.EntityFramework
{
    public abstract class BaseDatabaseServices<TDbContext> : IDatabaseServices where TDbContext : TaskNoteDbContext
    {
        public virtual void ConfigureDatabaseServices(IServiceCollection services)
        {
            services
                .AddSingleton<DbContextOptionsBuilder>()
                .AddSingleton<DbContextOptions>(_ => _.GetRequiredService<DbContextOptionsBuilder>().Options)
                .AddSingleton<IMigrate, DatabaseMigrate<TDbContext>>()
                .AddDbContext<TDbContext>()
                .AddDbContextFactory<TDbContext>()
                .AddSingleton<ITaskItemSession, TaskItemSession<TDbContext>>();
        }
    }
}
