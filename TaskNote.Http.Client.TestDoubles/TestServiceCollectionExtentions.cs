using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TaskNote.Http.Client.HttpUrls;

namespace TaskNote.Http.Client
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            services.UseTestOptions(new TestOptions(testName));
#if DEBUG
            services.AddHttpClient(_ => _.AddConfiguration<MockHttpClientServices>());
#else
            services.AddHttpClient(_ => _.AddProvider <Rest.RestHttpClientServices>());
#endif

            var provider = services.BuildServiceProvider();

            // ここでUserOptionsの値を変更して認証が通るようにするのもアリ

            return services
                .AddSingleton<IAuthService>(_ => new SpyAuthService(provider.GetRequiredService<IAuthService>()))
                .AddSingleton<ILogConfigDownloadService>(_ => new SpyLogConfigDownloadService(provider.GetRequiredService<ILogConfigDownloadService>()))
                .AddSingleton<ILogFileUploadService>(_ => new SpyLogFileUploadService(provider.GetRequiredService<ILogFileUploadService>()))
                .AddSingleton<ITaskService>(_ => new SpyTaskService(provider.GetRequiredService<ITaskService>()))
                ;
        }
    }
}
