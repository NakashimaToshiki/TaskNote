using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Database.EntityFramework.DbSqlite
{
    public class SqliteDatabaseServices : BaseDatabaseServices<TaskNoteDbContext>
    {
        public override void ConfigureDatabaseServices(IServiceCollection services)
        {
            base.ConfigureDatabaseServices(services);
            services
                .AddSingleton<IDatabaseOptions, SqliteDatabaseOptions>();
        }
    }
}
