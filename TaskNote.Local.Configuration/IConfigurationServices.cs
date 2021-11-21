using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Configuration
{
    public interface IConfigurationServices
    {
        void Configure(IServiceCollection services);
    }
}
