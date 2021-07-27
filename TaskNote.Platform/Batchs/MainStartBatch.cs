using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskNote.Entity;
using TaskNote.Models.Repositoris;

namespace TaskNote.Platform.Batchs
{
    public class MainStartBatch : IStartBatch
    {
        private readonly ILogger _logger;
        private readonly StartupWindowBatch _window;
        private readonly StorageMigrateBatch _storage;
        private readonly UserInfoBatch _userInfo;

        public MainStartBatch(ILogger logger, StartupWindowBatch window, StorageMigrateBatch storage, UserInfoBatch userInfo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _userInfo = userInfo ?? throw new ArgumentNullException(nameof(userInfo));
        }

        public async ValueTask<bool> RunAsync()
        {
            try
            {
                _logger.LogInformation("メイン画面を表示します。");
                _window.Run();

                _logger.LogInformation("ローカルストレージを更新開始");
                if (_storage.Run())
                {
                    _logger.LogInformation("ローカルストレージの更新に失敗。処理を中断します。");
                    return false;
                }

                _logger.LogInformation("ログイン処理を開始");
                if (await _userInfo.Run())
                {
                    _logger.LogInformation("ログイン失敗。処理を中断します。");
                    return false;
                }
                    
                _logger.LogInformation("ログイン後のサーバ通信を開始");

                return true;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "");
                return false;
            }
        }
    }

    /// <summary>
    /// アプリ起動時に表示するウィンドウ
    /// </summary>
    public class StartupWindowBatch
    {
        private readonly SynchronizationContext _synchro;
        private readonly IMainWindow _window;

        public StartupWindowBatch(SynchronizationContext synchro, IMainWindow window)
        {
            _synchro = synchro ?? throw new ArgumentNullException(nameof(synchro));
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public bool Run()
        {
            _synchro.Send(state =>
            {
                _window.Show();
            }, null);
            return false;
        }
    }

    /// <summary>
    /// アプリの物理ストレージをマイグレートします。
    /// </summary>
    public class StorageMigrateBatch
    {
        private readonly ILogger _logger;
        private readonly StorageMigrateRepository _repository;
        private readonly IMigrate _migrate;

        public StorageMigrateBatch(ILogger logger, StorageMigrateRepository repository, IMigrate migrate)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _migrate = migrate ?? throw new ArgumentNullException(nameof(migrate));
        }

        public bool Run()
        {
            try
            {
                _migrate.Migrate();
                var ret = _repository.Run();
                return ret != StorageMigrateRepositoryReturn.Error;
            }
            catch (Exception e)
            {
                _logger.LogCritical(e);
                return false;
            }
        }
    }

    public class LoginIntialBatch
    {
        private readonly ILogger _logger;

        public LoginIntialBatch(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

    }
}
