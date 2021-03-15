using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace TaskNote.Configuration
{
    public static class ConfigurationServicesCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IFileInfo sourceFile, IFileInfo defualtFile)
        {
            IConfiguration root;
            if (!sourceFile.Exists)
            {
                if (!defualtFile.Exists) throw new FileNotFoundException(defualtFile.PhysicalPath);
                File.Copy(defualtFile.PhysicalPath, sourceFile.PhysicalPath);
            }

            var directory = Path.GetDirectoryName(sourceFile.PhysicalPath);
            root = new ConfigurationBuilder().SetBasePath(directory).AddJsonFile(sourceFile.Name).Build();

            services.AddSingleton<IConfiguration>(root);
            return services;
        }
    }

}
