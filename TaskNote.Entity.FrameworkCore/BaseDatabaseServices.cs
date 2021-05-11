using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskNote.Entity.TaskItems;

namespace TaskNote.Entity.FrameworkCore
{
    public abstract class BaseDatabaseServices<TDbContext> : IDatabaseServices where TDbContext : TaskNoteDbContext
    {
        public virtual void Configure(IServiceCollection services)
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
