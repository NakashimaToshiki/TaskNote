﻿using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TaskNote.Batch;
using TaskNote.Platform;
using TaskNote.Platform.Wpf;
using TaskNote.TestDoubles;

namespace TaskNote.Desktop.Debug
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceCollection _services = new ServiceCollection();

        private readonly ServiceProvider _provider;

        public App()
        {
            _provider = _services
                .AddSingleton<SynchronizationContext>(new DispatcherSynchronizationContext(Dispatcher))
                .AddTestDoubles()
                .AddPlatform<WpfPlatformServices>()
                .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // DIのSystem.InvalidOperationExceptionの修正がしやすいようにTask.Run()の外に記述している
            var batch = _provider.GetService<IStartBatch>();

            var _ = Task.Run(async () =>
            {
                await batch.Run();

                Dispatcher.Invoke(() =>
                {
                    Application.Current.Shutdown();
                });
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var _ = Task.Run(async () =>
            {
                await _provider.GetService<IExitBatch>().Run();
                _provider.Dispose(); // IDisposeを実装しているクラスをすべて解放
                base.OnExit(e);
            });
        }
    }
}
