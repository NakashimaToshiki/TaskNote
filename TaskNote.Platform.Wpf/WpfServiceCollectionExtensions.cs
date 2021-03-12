using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Platform.Wpf
{
    public static class WpfServiceCollectionExtensions
    {
        public static IServiceCollection AddWpf(this IServiceCollection services)
        {
            services.AddSingleton<IMainWindow, MainWindow>();
            return services;
        }
    }
}
