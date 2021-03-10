using Microsoft.Extensions.DependencyInjection;
using TaskNote.Database;
using TaskNote.Database.EntityFramework;
using TaskNote.Database.EntityFramework.InMemory;
using TaskNote.Database.TaskItems;

namespace TaskNote.DependencyInjection.MicrosoftExtentions
{

    public interface IDbContext : IContainer
    {
    }

    public abstract class BaseDbContextContainer<TDbContext> : IDbContext where TDbContext : TaskNoteDbContext
    {
        public BaseDbContextContainer(IServiceCollection services)
        {
            services.AddSingleton<IMigrate, DatabaseMigrate<TDbContext>>();
            services.AddDbContext<TDbContext>();
            services.AddDbContextFactory<TDbContext>();
            services.AddSingleton<ITaskItemSession, TaskItemSession<TDbContext>>();
        }
    }

    public class DbSqliteContainer : BaseDbContextContainer<TaskNoteDbContext>
    {
        public DbSqliteContainer(IServiceCollection services) : base(services)
        {
        }
    }

    public class DbMemoryContainer : BaseDbContextContainer<TaskNoteDbContext>
    {
        public DbMemoryContainer(IServiceCollection services) : base(services)
        {
            services.AddSingleton<IMigrate, SpyMigrate>();
        }
    }
}
