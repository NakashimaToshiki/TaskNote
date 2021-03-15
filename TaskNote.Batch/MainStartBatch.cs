using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TaskNote.Batch
{
    public class MainStartBatch : IStartBatch
    {
        private readonly ILogger _logger;
        private readonly MainWindowStartBatch _window;

        public MainStartBatch(ILogger logger, MainWindowStartBatch window)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public async ValueTask<bool> Run()
        {
            try
            {
                _logger.LogInformation("開始します。");
                // ロギングの開始
                // ロギングを開始するには、トレースログのフォルダを生成する必要がある
                // ローカルストレージでフォルダの生成
                // マイグレーションの実行

                // スプラッシュ画面の表示？
                // 


                // 認証処理

                // メイン画面の表示
                await _window.Run();

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
