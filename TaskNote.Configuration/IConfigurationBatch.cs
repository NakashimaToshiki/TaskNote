using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace TaskNote.Configuration
{
    /// <summary>
    /// setting.json設定ファイルの読み込み
    /// </summary>
    public interface IConfigurationBatch
    {
        IConfigurationRoot GetConfiguration();
    }

    /// <summary>
    /// デクストップ用
    /// 実行ファイルと同じ場所にsettingファイルが存在する
    /// </summary>
    public class ConfigurationBatch : IConfigurationBatch
    {
        private readonly IFileInfoFacade fileInfo;

        public ConfigurationBatch(IFileInfoFacade fileInfoFacade)
        {
            fileInfo = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public IConfigurationRoot GetConfiguration()
        {
            var settingFile = new FileInfo(Path.Combine(fileInfo.InstalledLocation, fileInfo.AppSetting));
            
            return new ConfigurationBuilder().SetBasePath(settingFile.DirectoryName).AddJsonFile(settingFile.Name).Build();
        }
    }
}
