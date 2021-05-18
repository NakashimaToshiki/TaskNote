using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TaskNote.Http.Client.HttpUrls;

namespace TaskNote.Http.Client
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            return services
                .UseTestOptions(new TestOptions(testName))
                .AddHttpTest()
                ;
        }

        public static IServiceCollection AddHttpTest(this IServiceCollection services) // ここBuildServiceProviderを呼び出しているのでUseにする？
        {
#if DEBUG
            services.AddHttpClient(_ => _.AddConfiguration<MockHttpClientServices>());
#else
            services.AddHttpClient(_ => _.AddProvider<Rest.RestHttpClientServices>());
#endif

            var provider = services.BuildServiceProvider();

            // ここでUserOptionsの値を変更して認証が通るようにするのもアリ

            return services
                .AddSingleton(_ => new SpyAuthService(provider.GetRequiredService<IAuthService>()))
                .AddSingleton(_ => new SpyLogConfigDownloadService(provider.GetRequiredService<ILogConfigDownloadService>()))
                .AddSingleton(_ => new SpyLogFileUploadService(provider.GetRequiredService<ILogFileUploadService>()))
                .AddSingleton(_ => new SpyTaskService(provider.GetRequiredService<ITaskService>()))
                .AddSingleton<IAuthService>(_ => _.GetRequiredService<SpyAuthService>())
                .AddSingleton<ILogConfigDownloadService>(_ => _.GetRequiredService<SpyLogConfigDownloadService>())
                .AddSingleton<ILogFileUploadService>(_ => _.GetRequiredService<SpyLogFileUploadService>())
                .AddSingleton<ITaskService>(_ => _.GetRequiredService<SpyTaskService>())
                ;
        }
    }
}
