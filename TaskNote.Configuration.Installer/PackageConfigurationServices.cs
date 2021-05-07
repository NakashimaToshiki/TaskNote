using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Configuration.Installer
{
    public class PackageConfigurationServices : IConfigurationServices
    {
        public void Configure(IServiceCollection services)
        {
            services
                .AddSingleton<IVersion, PackageVersion>();
        }
    }
}
