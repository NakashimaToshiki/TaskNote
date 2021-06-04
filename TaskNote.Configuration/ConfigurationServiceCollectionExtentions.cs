using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TaskNote.Configuration
{
    public static class ConfigurationServiceCollectionExtentions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var configureOptions = new DatabaseConfigureOptions(configuration);
            var databaseOptions = new DatabaseOptions();
            configureOptions.Configure(databaseOptions);
            return services
                .AddSingleton(configuration)
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<IConfigureOptions<DatabaseOptions>>(new DatabaseConfigureOptions(configuration))
                .AddSingleton<IDatabaseOptions>(databaseOptions)
                ;
        }
    }
}
