using Microsoft.Extensions.DependencyInjection;
using System.Windows.Threading;

namespace TaskNote.Platform.Wpf
{
    public static class WpfPlatformServiceCollectionExtensions
    {
        public static IServiceCollection AddWpfPlatform(this IServiceCollection services, Dispatcher dispatcher)
        {

            return services
                .AddSingleton(dispatcher)
                .AddSingleton<ApplicationOnStartup>()
                ;
        }
    }
}
