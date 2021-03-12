using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskNote.Database.EntityFramework.DbSqlite;

namespace TaskNote.Desktop
{
    public class DbContextFactory : IDesignTimeDbContextFactory<TaskNoteSqliteContext>
    {
        public TaskNoteSqliteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskNoteSqliteContext>();

            return new TaskNoteSqliteContext(new SqliteDatabaseOptions(), optionsBuilder.Options);
        }
    }
}
