﻿using Microsoft.Extensions.DependencyInjection;
using TaskNote.Platform;
using TaskNote.Platform.Wpf;

namespace TaskNote.DependencyInjection.Wpf
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