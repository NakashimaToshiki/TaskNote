using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.FrameworkCore
{
    public abstract class BaseDatabaseServices<TDbContext> : IDatabaseServices where TDbContext : TaskNoteDbContext
    {
        public virtual void Configure(IServiceCollection services)
        {
            services
                .AddDbContext<TDbContext>()
                .AddDbContextFactory<TDbContext>()
                .AddSingleton<IMigrate, DatabaseMigrate<TDbContext>>()
                .AddSingleton<DbContextOptionsBuilder>()
               // .AddSingleton<DbContextOptions>(_ => _.GetRequiredService<DbContextOptionsBuilder>().Options)
                .AddSingleton<ITaskItemSession, TaskItemSession<TDbContext>>();
        }
    }
}
