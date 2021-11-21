using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskNote.Entity.FrameworkCore.DbSqlite;

namespace TaskNote.Wpf
{
    public class DbContextFactory : IDesignTimeDbContextFactory<TaskNoteSqliteContext>
    {
        public TaskNoteSqliteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskNoteSqliteContext>();

            return new TaskNoteSqliteContext(new FileInfoFacade(), optionsBuilder.Options);
        }
    }
}
