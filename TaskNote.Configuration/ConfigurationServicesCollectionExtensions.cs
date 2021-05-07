using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace TaskNote.Configuration
{
    public static class ConfigurationServicesCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IFileInfo sourceFile)
        {
            var directory = Path.GetDirectoryName(sourceFile.PhysicalPath);
            var root = new ConfigurationBuilder().SetBasePath(directory).AddJsonFile(sourceFile.Name).Build();

            services.AddSingleton<IConfiguration>(root);
            return services;
        }
    }

}
