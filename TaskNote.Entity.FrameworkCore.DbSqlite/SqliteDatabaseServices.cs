using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity.FrameworkCore.DbSqlite
{
    public class SqliteDatabaseServices : BaseDatabaseServices<TaskNoteSqliteContext>
    {
        public override void Configure(IServiceCollection services)
        {
            base.Configure(services);
        }
    }
}
