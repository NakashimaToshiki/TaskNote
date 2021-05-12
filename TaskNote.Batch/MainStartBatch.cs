using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TaskNote.Entity;

namespace TaskNote.Batch
{
    public class MainStartBatch : IStartBatch
    {
        private readonly ILogger _logger;
        private readonly IMigrate _migrate;
        private readonly MainWindowStartBatch _window;

        public MainStartBatch(ILogger logger, IMigrate migrate, MainWindowStartBatch window)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _migrate = migrate;
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public async ValueTask<bool> RunAsync()
        {
            try
            {
                _logger.LogInformation("開始します。");

                // データベースの更新
                _migrate.Migrate();

                // バージョン情報比較

                // ユーザー情報読み込み

                // メイン画面の表示
                await _window.RunAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "");
                return false;
            }
        }
    }
}
