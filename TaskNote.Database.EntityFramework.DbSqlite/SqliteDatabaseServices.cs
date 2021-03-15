using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Database.EntityFramework.DbSqlite
{
    public class SqliteDatabaseServices : BaseDatabaseServices<TaskNoteDbContext>
    {
        public override void Configure(IServiceCollection services)
        {
            base.Configure(services);
            services
                .AddSingleton<IDatabaseOptions, SqliteDatabaseOptions>();
        }
    }
}
