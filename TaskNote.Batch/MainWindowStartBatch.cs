using System;
using System.Threading;
using System.Threading.Tasks;
using TaskNote.Platform;

namespace TaskNote.Batch
{
    public class MainWindowStartBatch : IStartBatch
    {
        private readonly IMainWindow _mainWindow;
        private readonly SynchronizationContext _synchronization;

        public MainWindowStartBatch(IMainWindow mainWindow, SynchronizationContext synchronization)
        {

            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            _synchronization = synchronization ?? throw new ArgumentNullException(nameof(synchronization));
        }

        public async ValueTask<bool> Run()
        {
            return await Task.Run(() =>
            {
                _synchronization.Send(state =>
                {
                    _mainWindow.ShowDialog();
                }, null);
                return true;
            });
        }
    }
}
