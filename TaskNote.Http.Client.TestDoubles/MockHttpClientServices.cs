using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace TaskNote.Http.Client
{
    public class MockHttpClientServices : IHttpClientServices
    {
        public void Configure(IServiceCollection services) =>
            services
            .AddSingleton<IAuthService>(_ => new Mock<IAuthService>().Object)
            .AddSingleton<ILogConfigDownloadService>(_ => new Mock<ILogConfigDownloadService>().Object)
            .AddSingleton<ILogFileUploadService>(_ => new Mock<ILogFileUploadService>().Object)
            .AddSingleton<ITaskService>(_ => new Mock<ITaskService>().Object)
            ;
    }
}
