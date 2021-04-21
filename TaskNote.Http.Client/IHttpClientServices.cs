using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Http.Client
{
    public interface IHttpClientServices
    {
        void Configure(IServiceCollection services);
    }
}
