using Microsoft.Extensions.DependencyInjection;
using System.IO;
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
            services.AddDatabase<FrameworkCore.DbSqlite.SqliteDatabaseServices>();
            var provider = services.BuildServiceProvider();
            // データベースをファイル削除
            var info = new FileInfo(provider.GetRequiredService<IFileInfoFacade>().Database);
            if (info.Exists) info.Delete();

            // データベース生成
            provider.GetRequiredService<IMigrate>().Migrate();
#endif


            return services;
        }
    }
}