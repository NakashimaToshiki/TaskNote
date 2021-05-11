using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity.FrameworkCore.DbSqlite
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
