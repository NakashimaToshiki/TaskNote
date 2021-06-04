using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace TaskNote.Entity
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            services
                .UseTestOptions(new TestOptions(testName))
                ;
            var provider = services.BuildServiceProvider();
            return services.AddTest(provider.GetService<IDatabaseOptions>());
        }

        public static IServiceCollection AddTest(this IServiceCollection services, IDatabaseOptions options)
        {
            switch (options.Type)
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
            var databaseFileInfo = provider.GetRequiredService<IFileInfoFacade>().GetDatabaseFileInfo();
            if (databaseFileInfo.Exists) databaseFileInfo.Delete();

            // データベース生成
            provider.GetRequiredService<IMigrate>().Migrate();

            return services;
        }
    }
}