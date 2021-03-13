using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Platform
{
    public interface IPlatformServices
    {
        void ConfigureServices(IServiceCollection services);
    }
}
