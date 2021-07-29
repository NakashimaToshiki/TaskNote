using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaskNote.Models.Repositoris;

namespace TaskNote.Platform.Batchs
{
    public class MainExitBatch : IExitBatch
    {
        private readonly ILogger _logger;
        private readonly UploadTraceLogRepository _traceLog;

        public MainExitBatch(ILogger logger, UploadTraceLogRepository _torageLog)
        {
            _logger = logger;
            _traceLog = _torageLog;
        }

        public bool Run()
        {
            var task = Task.Run(async () =>
            {
                return await _traceLog.UploadAndDelete();
            });
            return task.Result;
        }
    }
}
