using Microsoft.Extensions.DependencyInjection;
using System.Windows.Threading;
using System.Threading;

namespace TaskNote.Platform.Wpf
{
    public static class WpfPlatformServiceCollectionExtensions
    {
        public static IServiceCollection AddWpfPlatform(this IServiceCollection services, Dispatcher dispatcher)
        {
            return services
                .AddPlatform<WpfPlatformServices>(new DispatcherSynchronizationContext(dispatcher))
                .AddSingleton(dispatcher)
                .AddSingleton<ApplicationOnStartup>()
                ;
        }
    }
}
