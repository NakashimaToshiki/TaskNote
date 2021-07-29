using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Configuration;
using TaskNote.Storage;

namespace TaskNote.Models.Repositoris
{
    /// <summary>
    /// <see cref="StorageMigrateRepository.Run"/>のリターンコード
    /// </summary>
    public enum StorageMigrateRepositoryReturn
    {
        /// <summary>
        /// エラーが発生した。
        /// </summary>
        Error,

        /// <summary>
        /// バージョンが一致した
        /// </summary>
        VersionMatch,

        /// <summary>
        /// ストレージを更新した
        /// </summary>
        StorageRefresh,
    }

    /// <summary>
    /// アップデートを検出したらローカルストレージを更新する機能を提供します。
    /// </summary>
    public class StorageMigrateRepository
    {
        private readonly ILogger _logger;
        private readonly ILocalStorage _localStorage;
        private readonly IVersion _version;
        private readonly IVersionConfiguration _config;

        public StorageMigrateRepository(ILogger logger, ILocalStorage localStorage, IVersion version, IVersionConfiguration config)
        {
            _logger = logger;
            _localStorage = localStorage;
            _version = version ?? throw new ArgumentNullException(nameof(version));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public StorageMigrateRepositoryReturn Run()
        {
            try
            {
                var versionName = _version.GetVersionName();
                _logger.LogInformation($"現在のアプリバージョン：{versionName ?? "None"}");

                if (!IsMatchVersion(_config.Load()))
                {
                    _localStorage.AllDeleteApplication();
                    _config.Save(_version.GetVersionName());
                    return StorageMigrateRepositoryReturn.StorageRefresh;
                }

                return StorageMigrateRepositoryReturn.VersionMatch;
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return StorageMigrateRepositoryReturn.Error;
            }
        }

        private bool IsMatchVersion(string configValue)
        {
            try
            {
                return _version.IsMatchVersion(configValue);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return false;
            }
        }
    }
}
