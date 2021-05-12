using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TaskNote
{
    /// <summary>
    /// ロギング情報
    /// </summary>
    public struct LoggingOptions
    {
        public string FilePath;

        public string LogFolder;

        public IConfiguration Configuration;
    }

    /// <summary>
    /// ロギング情報を取得する
    /// </summary>
    public interface ILoggingBatch
    {
        LoggingOptions GetOptions();
    }


    /// <summary>
    /// デクストップ用
    /// </summary>
    public class LoggingBatch : ILoggingBatch
    {
        private readonly IConfiguration _configuration;
        private readonly IFileInfoFacade _fileInfoFacade;

        public LoggingBatch(IConfiguration configuration, IFileInfoFacade fileInfoFacade)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public LoggingOptions GetOptions()
        {
            return new LoggingOptions()
            {
                FilePath = Path.Combine(_fileInfoFacade.InstalledLocation, _fileInfoFacade.NLog),
                LogFolder = Path.Combine(_fileInfoFacade.ApplicationPath, _fileInfoFacade.TraceLogFolder),
                Configuration = _configuration.GetSection("Logging")
            };
        }
    }
}
