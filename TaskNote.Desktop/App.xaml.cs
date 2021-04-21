﻿using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TaskNote.Batch;
using TaskNote.Database;
using TaskNote.Database.EntityFramework.DbSqlite;
using TaskNote.Logging;
using TaskNote.Platform;
using TaskNote.Platform.Wpf;
using TaskNote.Storage;
using TaskNote.Storage.BuiltIn;
using TaskNote.Http.Client;
using TaskNote.Http.Client.HttpUrls;
using TaskNote.Http.Client.Rest;

namespace TaskNote.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _provider;

        public App()
        {
            _provider = new ServiceCollection()
                .AddSingleton<Dispatcher>(Dispatcher)
                .AddSingleton<SynchronizationContext>(new DispatcherSynchronizationContext(Dispatcher))
                .AddDatabase<SqliteDatabaseServices>()
                .AddPlatform<WpfPlatformServices>()
                .AddBatch()
                .AddStorage<BuiltInStorageServices>()
                .AddHttpClient(_ => _.AddProvider<RestHttpClientServices>())
                .AddNLog()
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
