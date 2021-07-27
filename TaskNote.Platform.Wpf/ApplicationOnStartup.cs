using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TaskNote.Platform.Batchs;

namespace TaskNote.Platform.Wpf
{
    public class ApplicationOnStartup
    {
        private readonly ILogger _logger;
        private readonly IStartBatch _batch;
        private readonly Dispatcher _dispatcher;
        private readonly IMessageBox _message;

        public ApplicationOnStartup(ILogger logger, IStartBatch batch, Dispatcher dispatcher, IMessageBox message)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _batch = batch ?? throw new ArgumentNullException(nameof(batch));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public void Start()
        {
            var _ = Task.Run(async () =>
            {
                if (!await _batch.RunAsync())
                {
                    _dispatcher.Invoke(() =>
                    {
                        _message.Show("正常起動できませんでした。アプリを終了します。\r\n詳細はログファイルを確認して下さい。", "起動エラー");
                        _logger.LogInformation("正常起動しませんでした。アプリを終了します。");
                        Application.Current.Shutdown();
                    });
                }
            });
        }
    }
}
