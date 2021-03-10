using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TaskNote.Batch
{
    public class MainStartBatch : IStartBatch
    {
        private readonly ILogger _logger;

        public MainStartBatch(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<bool> Run()
        {
            try
            {
                await Task.Delay(1);
                // ログ開始？
                // スプラッシュ画面の表示？
                // 

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
