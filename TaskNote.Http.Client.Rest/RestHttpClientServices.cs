using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Http.Client.Rest
{
    public class RestHttpClientServices : IHttpClientServices
    {
        public void Configure(IServiceCollection services) =>
            services
            .AddSingleton<ClientFactory>()
            .AddSingleton<IAuthService, AuthService>()
            .AddSingleton<ILogConfigDownloadService, LogConfigDownloadService>()
            .AddSingleton<ILogFileUploadService, LogFileUploadService>()
            .AddSingleton<ITaskService, TaskService>()
            ;
    }
}
