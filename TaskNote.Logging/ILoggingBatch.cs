using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TaskNote.Storage;

namespace TaskNote.Logging
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
                LogFolder = Path.Combine(_fileInfoFacade.InstalledLocation, _fileInfoFacade.TraceLogFolder),
                Configuration = _configuration.GetSection("Logging")
            };
        }
    }

    /// <summary>
    /// パッケージ版用
    /// </summary>
    public class PackageLoggingBatch : ILoggingBatch
    {
        private readonly IConfiguration _configuration;
        private readonly IFileInfoFacade _fileInfoFacade;

        public PackageLoggingBatch(IConfiguration configuration, IFileInfoFacade fileInfoFacade)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public LoggingOptions GetOptions()
        {
            var nlog = new FileInfo(Path.Combine(_fileInfoFacade.ApplicationPath, _fileInfoFacade.NLog));
            if (!nlog.Exists)
            {
                var nlogDefualt = new FileInfo(Path.Combine(_fileInfoFacade.InstalledLocation, _fileInfoFacade.NLog));
                if (!nlogDefualt.Exists) throw new FileNotFoundException(nlogDefualt.FullName);
                File.Copy(nlogDefualt.FullName, nlog.FullName);
            }

            return new LoggingOptions()
            {
                FilePath = Path.Combine(_fileInfoFacade.ApplicationPath, _fileInfoFacade.NLog),
                LogFolder = Path.Combine(_fileInfoFacade.ApplicationPath, _fileInfoFacade.TraceLogFolder),
                Configuration = _configuration.GetSection("Logging")
            };
        }
    }
}
