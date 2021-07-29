using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskNote.Entity.FrameworkCore;

namespace TaskNote.Models
{
    public static class ServiceProviderCreateDatabaseExtentions
    {
        public static TaskNoteDbContext CreateDatabase(this ServiceProvider provider)
        {
#if DEBUG
            return provider.GetRequiredService<IDbContextFactory<Entity.FrameworkCore.InMemory.TaskNoteInMemoryContext>>().CreateDbContext();
#else
            return provider.GetRequiredService<IDbContextFactory<Entity.FrameworkCore.DbSqlite.TaskNoteSqliteContext>>().CreateDbContext();
#endif
        }
    }
}
