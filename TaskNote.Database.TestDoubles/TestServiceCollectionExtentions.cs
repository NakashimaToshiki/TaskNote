using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;

namespace TaskNote.Entity
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            services
                .UseTestOptions(new TestOptions(testName))
                ;
            // var dataOptions = services.BuildServiceProvider().GetService<IOptions<DatabaseOptions>>();
            var dataOptions = services.BuildServiceProvider().GetService<IConfigureOptions<DatabaseOptions>>();
            var options = new DatabaseOptions();
            dataOptions.Configure(options);
            return services.AddTest(options.Type);
        }

        public static IServiceCollection AddTest(this IServiceCollection services, string key)
        {
            switch (key)
            {
                case "Sqlite":
                    return services.UseSqliteTest();
                case "Memory":
                    return services.AddDatabase<FrameworkCore.InMemory.InMemoryDatabaseServices>();
            }
            return services;
        }

        private static IServiceCollection UseSqliteTest(this IServiceCollection services)
        {
            services.AddDatabase<FrameworkCore.DbSqlite.SqliteDatabaseServices>();
            var provider = services.BuildServiceProvider();
            
            // データベースをファイル削除
            provider.GetRequiredService<IFileInfoFacade>().GetDatabaseFileInfo().Delete();

            // データベース生成
            provider.GetRequiredService<IMigrate>().Migrate();

            return services;
        }
    }
}