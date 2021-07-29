using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            var configureOptions = provider.GetService<IConfigureOptions<DatabaseOptions>>();
            var options = new DatabaseOptions();
            configureOptions.Configure(options);

            return services.AddDatabaseTest(options);
        }

        public static IServiceCollection AddDatabaseTest(this IServiceCollection services, IDatabaseOptions options)
        {
            // ここでダミーのデータを生成するクラスを注入する
            //services.AddSingleton<ITaskEntityListCreater, >

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