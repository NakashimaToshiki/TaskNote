using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace TaskNote.Entity
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            services.UseTestOptions(new TestOptions(testName));

#if DEBUG
            services.AddDatabase<FrameworkCore.InMemory.InMemoryDatabaseServices>();
#else
            services.UseSqliteTest();
#endif

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