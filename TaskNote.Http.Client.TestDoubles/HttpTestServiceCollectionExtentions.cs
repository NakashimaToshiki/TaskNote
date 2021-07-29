using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Runtime.CompilerServices;
using TaskNote.Http.Client.HttpUrls;
using System.Net;

namespace TaskNote.Http.Client
{
    public static class HttpTestServiceCollectionExtentions
    {
        public static IServiceCollection UseHttpTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            return services
                .UseTestOptions(new TestOptions(testName))
                .AddHttpTest()
                ;
        }

        public static IServiceCollection AddHttpTest(this IServiceCollection services) 
        {

#if DEBUG
            services.AddHttpClient(_ => _.AddConfiguration<MockHttpClientServices>());
#else
            services.AddHttpClient(_ => _.AddProvider<Rest.RestHttpClientServices>());
#endif

            // ここBuildServiceProviderを呼び出しているのでUseにすべき
            // ⇒ Spyはテストコード側で差し込むように変更するのでここのproviderは消える予定
            var provider = services.BuildServiceProvider();

            // ここでUserOptionsの値を変更して認証が通るようにするのもアリ

            return services
                .AddSingleton(_ => new SpyAuthService(provider.GetRequiredService<IAuthService>()))
                .AddSingleton(_ => new SpyLogConfigDownloadService(provider.GetRequiredService<ILogConfigDownloadService>()))
                .AddSingleton(_ => new SpyLogFileUploadService(provider.GetRequiredService<IUploadTraceLogService>()))
                .AddSingleton(_ => new SpyTaskService(provider.GetRequiredService<ITaskService>()))
                .AddSingleton<IAuthService>(_ => _.GetRequiredService<SpyAuthService>())
                .AddSingleton<ILogConfigDownloadService>(_ => _.GetRequiredService<SpyLogConfigDownloadService>())
                .AddSingleton<IUploadTraceLogService>(_ => _.GetRequiredService<SpyLogFileUploadService>())
                .AddSingleton<ITaskService>(_ => _.GetRequiredService<SpyTaskService>())
                ;
        }

        public static IServiceCollection AddSpyAuthServiceInHttpClientException(this IServiceCollection services)
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(_ => _.GetAuthentication()).Throws<HttpClientException>();
            return services
                .AddSingleton(_ => new SpyAuthService(mock.Object))
                .AddSingleton<IAuthService>(_ => _.GetRequiredService<SpyAuthService>()) // ここ重複コード
                ;
        }

        public static IServiceCollection AddUnauthor(this IServiceCollection services)
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(_ => _.GetAuthentication()).Throws(new HttpRequestException(HttpStatusCode.Unauthorized));
            return services
                .AddSingleton(_ => new SpyAuthService(mock.Object))
                .AddSingleton<IAuthService>(_ => _.GetRequiredService<SpyAuthService>()) // ここ重複コード
                ;
        }
    }
}
