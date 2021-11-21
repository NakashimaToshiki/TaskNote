using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TaskNote.WinRT
{

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
            var fileInfo = new FileInfo(Path.Combine(_fileInfoFacade.ApplicationLocation, _fileInfoFacade.NLog));
            if (!fileInfo.Exists)
            {
                var defualtFileInfo = new FileInfo(Path.Combine(_fileInfoFacade.InstalledLocation, _fileInfoFacade.NLog));
                if (!defualtFileInfo.Exists) throw new FileNotFoundException(defualtFileInfo.FullName);
                File.Copy(defualtFileInfo.FullName, fileInfo.FullName);
            }

            return new LoggingOptions()
            {
                FilePath = _fileInfoFacade.GetNLogFileInfo(),
                LogFolder = _fileInfoFacade.GetTraceLogDirectoryInfo(),
                Configuration = _configuration.GetSection("Logging")
            };
        }
    }
}
