using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TaskNote.Batch;
using TaskNote.Configuration;
using TaskNote.Entity;
using TaskNote.Entity.FrameworkCore.DbSqlite;
using TaskNote.Http.Client;
using TaskNote.Http.Client.HttpUrls;
using TaskNote.Http.Client.Rest;
using TaskNote.Installer;
using TaskNote.Platform;
using TaskNote.Platform.Wpf;
using TaskNote.Logging;

namespace TaskNote.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly ServiceCollection _services = new ServiceCollection();

        public App()
        {
            _services.AddDesktopOrPackage();

            // 設定ファイルの読み込み
            _services.AddSingleton(_services.BuildServiceProvider().GetService<IConfigurationBatch>().GetConfiguration());

            // NLogファイルの読み込み
            _services.AddTaskNoteLogging(_services.BuildServiceProvider().GetService<ILoggingBatch>().GetOptions());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // DIのSystem.InvalidOperationExceptionの修正がしやすいようにTask.Run()の外に記述している
            var batch = _services
                .AddSingleton<Dispatcher>(Dispatcher)
                .AddSingleton<SynchronizationContext>(new DispatcherSynchronizationContext(Dispatcher))
                .AddDatabase<SqliteDatabaseServices>()
                .AddPlatform<WpfPlatformServices>()
                .AddBatch()
                .AddHttpClient(_ => _.AddProvider<RestHttpClientServices>())
                .BuildServiceProvider().GetService<IStartBatch>();

            var _ = Task.Run(async () =>
            {
                await batch.RunAsync();

                Dispatcher.Invoke(() =>
                {
                    Application.Current.Shutdown();
                });
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var provider = _services.BuildServiceProvider();
            provider.GetService<IExitBatch>().Run();
            provider.Dispose(); // IDisposeを実装しているクラスをすべて解放
            base.OnExit(e);
        }
    }
}
