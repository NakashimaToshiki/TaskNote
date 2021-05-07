using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Configuration.Desktop
{
    public class DesktopConfigurationServices : IConfigurationServices
    {
        public void Configure(IServiceCollection services)
        {
            services
                .AddSingleton<IVersion, AssemblyVersion>();
        }
    }
}
