using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TaskNote.Batch
{
    public class MainStartBatch : IStartBatch
    {
        private readonly ILogger _logger;
        private readonly MainWindowStartBatch _window;

        public MainStartBatch(MainWindowStartBatch window)
        {
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public async ValueTask<bool> Run()
        {
            try
            {
                // ログ開始？
                // スプラッシュ画面の表示？
                // 

                await _window.Run();

                // ログイン

                // ストレージの確認

                // メイン画面の表示

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
