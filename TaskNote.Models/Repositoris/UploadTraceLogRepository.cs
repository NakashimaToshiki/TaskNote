using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Http.Client;

namespace TaskNote.Models.Repositoris
{
    /// <summary>
    /// トレースログを送信する機能を提供します。
    /// </summary>
    public class UploadTraceLogRepository
    {
        private readonly ILogger _logger;
        private readonly IUploadTraceLogService _upload;
        private readonly IFileInfoFacade _fileInfoFacade;

        public UploadTraceLogRepository(ILogger logger, IUploadTraceLogService upload, IFileInfoFacade fileInfoFacade)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _upload = upload ?? throw new ArgumentNullException(nameof(upload));
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public async Task<bool> UploadAndDelete()
        {
            try
            {
                var files = _fileInfoFacade.GetTraceLogDirectoryInfo().GetFiles();

                bool ret = true;

                await Task.WhenAll(files.Select(async file =>
                {
                    try
                    {
                        if (await _upload.Upload(file.FullName))
                        {
                            file.Delete();
                        }
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _logger.LogWarning(e);
                    }
                }));

                return ret;
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return false;
            }
        }
    }
}
