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
        IConfiguration GetConfiguration();
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

        public IConfiguration GetConfiguration()
        {
            var settingFile = new FileInfo(Path.Combine(fileInfo.InstalledLocation, fileInfo.AppSetting));
            
            return new ConfigurationBuilder().SetBasePath(settingFile.DirectoryName).AddJsonFile(settingFile.Name).Build();
        }
    }

    /// <summary>
    /// パッケージ用
    /// アプリケーションフォルダのsetting.jsonファイルを読み込み、
    /// 存在しなければ、インストーラーフォルダにあるデフォルトのsetting.jsonをコピーしてくる
    /// </summary>
    public class PackageConfigurationBatch : IConfigurationBatch
    {
        private readonly IFileInfoFacade fileInfo;

        public PackageConfigurationBatch(IFileInfoFacade fileInfoFacade)
        {
            fileInfo = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public IConfiguration GetConfiguration()
        {
            // setting.jsonファイルコピー
            var settingFile = new FileInfo(Path.Combine(fileInfo.ApplicationPath, fileInfo.AppSetting));
            if (!settingFile.Exists)
            {
                var settingFileDefualt = new FileInfo(Path.Combine(fileInfo.InstalledLocation, fileInfo.AppSetting));
                if (!settingFileDefualt.Exists) throw new FileNotFoundException(settingFileDefualt.FullName);
                File.Copy(settingFileDefualt.FullName, settingFile.FullName);
            }

            return new ConfigurationBuilder().SetBasePath(settingFile.DirectoryName).AddJsonFile(settingFile.Name).Build();
        }
    }
}
