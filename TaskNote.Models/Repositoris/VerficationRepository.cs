using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TaskNote.Http.Client;
using TaskNote.Models.VerificationModels;

namespace TaskNote.Models.Repositoris
{
    public class VerficationRepository
    {
        private readonly ILogger _logger;
        private readonly IAuthService _service;

        public VerficationRepository(ILogger _logger, IAuthService _service)
        {
            _logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            _service = _service ?? throw new ArgumentNullException(nameof(_service));
        }

        public async ValueTask<BaseVerificationModel> Verfication()
        {
            try
            {
                var response = await _service.GetAuthentication();
                _logger.LogInformation("認証成功");
                return new VerificationSuccessModel();
            }
            catch (HttpRequestException e)
            {
                _logger.LogWarning(e, "");
                if(e.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new VerificationErrorModel("認証に失敗しました。入力情報を確認してください。");
                }
                return new VerificationErrorModel($"認証失敗。エラーコード：{e.StatusCode} {e.Message}");
            }
            catch (HttpClientException)
            {
                // 認証エラーがサーバかクライアントどちらが原因か分かるようにする。
                return new VerificationNetworkModel();
            }
        }
    }
}
