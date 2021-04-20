using System.Threading.Tasks;
using TaskNote.Storage;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Logging
{
    /// <summary>
    /// ロギングを開始するためにバッチ
    /// </summary>
    public interface ILoggingBatch : IBatch
    {
    }

    public static class LoggingBatchExtentions
    {
        public static IServiceCollection UseLogging(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            return services;
        }
    }

    public class LoggingBatch : ILoggingBatch
    {
        private readonly IStorageDirectoryOptions _options;

        public LoggingBatch(IStorageDirectoryOptions options)
        {
            _options = options ?? throw new System.ArgumentNullException(nameof(options));
        }

        public async ValueTask<bool> Run()
        {
            throw new System.NotImplementedException();
        }
    }
    public class PackegeLoggingBatch : ILoggingBatch
    {
        public async ValueTask<bool> Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
