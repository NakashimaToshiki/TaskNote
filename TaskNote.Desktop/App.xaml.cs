using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using TaskNote.Configuration;
using TaskNote.Entity;
using TaskNote.Entity.FrameworkCore.DbSqlite;
using TaskNote.Http.Client;
using TaskNote.Http.Client.HttpUrls;
using TaskNote.Http.Client.Rest;
using TaskNote.Logging;
using TaskNote.Platform;
using TaskNote.Platform.Batchs;
using TaskNote.Platform.Wpf;
using TaskNote.WinRT;
using TaskNote.Models;
using TaskNote.Storage;

namespace TaskNote.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly ServiceCollection _services = new ServiceCollection();

        private ServiceProvider _provider;

        public App()
        {
            _services.AddDesktopOrPackageOptions();

            // 設定ファイルの読み込み
            _services.AddConfiguration(_services.BuildServiceProvider().GetService<IConfigurationBatch>().GetConfiguration());

            // NLogファイルの読み込み
            _services.AddTaskNoteLogging(_services.BuildServiceProvider().GetService<ILoggingBatch>().GetOptions());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _provider = _services
                .AddStorage<StorageServices>()
                .AddDatabase<SqliteDatabaseServices>()
                .AddHttpClient(_ => _.AddProvider<RestHttpClientServices>())
                .AddWpfPlatform(Dispatcher)
                .BuildServiceProvider();
            
            var batch = _provider.GetService<ApplicationOnStartup>();
            batch.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var batch = _provider.GetService<IExitBatch>();
            batch.Run();

            //_provider.Dispose(); // IDisposeを実装しているクラスをすべて解放
            base.OnExit(e);
        }
    }
}
