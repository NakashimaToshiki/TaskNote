using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskNote.Configuration;
using TaskNote.Models.Repositoris;
using TaskNote.Models.VerificationModels;

namespace TaskNote.Platform.Batchs
{
    public class UserInfoBatch
    {
        private readonly ILogger _logger;
        private readonly SynchronizationContext _synchro;
        private readonly IUserInfoView _view;
        private readonly VerficationRepository _verfication;
        private readonly IUserConfiguration _userConfig;

        public UserInfoBatch(ILogger logger, SynchronizationContext synch, IUserInfoView view, VerficationRepository verfication, IUserConfiguration userConfig)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _synchro = synch ?? throw new ArgumentNullException(nameof(synch));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _verfication = verfication ?? throw new ArgumentNullException(nameof(verfication));
            _userConfig = userConfig ?? throw new ArgumentNullException(nameof(userConfig));
        }

        public async ValueTask<bool> Run(int retryWaitMilliseconds = 5000, int retryMax = 3)
        {
            try
            {
                BaseVerificationModel model = NullVerificationModel.Instance;

                // 設定ファイルからユーザー情報を取得
                bool loadConfigSuccess;
                try
                {
                    loadConfigSuccess = _userConfig.Load();
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e);
                    loadConfigSuccess = false;
                }

                if (loadConfigSuccess)
                {
                    for (int cnt = 0; cnt < retryMax; cnt++)
                    {
                        model = await _verfication.Verfication();
                        if (model is VerificationNetworkModel)
                        {
                            if (cnt == 0) _logger.LogWarning(new Exception("インターネット接続エラー、接続を繰り返します"));
                            await Task.Delay(retryWaitMilliseconds);
                        }
                        else
                        {
                            // インターネット接続失敗以外
                            break;
                        }
                    }

                    switch (model)
                    {
                        case VerificationErrorModel _:
                            _logger.LogWarning(new Exception("インターネット接続エラー"), "{0}回繰り返しログインを試みましたが接続できませんでした。");
                            return false;
                    }
                }

                if (model is VerificationSuccessModel) return true;

                // 認証失敗はユーザー入力ダイアログを表示
                _synchro.Send(state =>
                {
                    _view.ShowDialog();
                }, null);

                switch (_view.Result)
                {
                    case UserInfoDialogResult.OK:
                        return true;
                    case UserInfoDialogResult.Cancel:
                        return false;
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e);
                return false;
            }
        }
    }
}
