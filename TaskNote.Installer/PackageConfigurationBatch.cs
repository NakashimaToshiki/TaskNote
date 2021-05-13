using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TaskNote.Configuration;

namespace TaskNote.Installer
{
    /// <summary>
    /// パッケージ用
    /// アプリケーションフォルダのsetting.jsonファイルを読み込み、
    /// 存在しなければ、インストーラーフォルダにあるデフォルトのsetting.jsonをコピーしてくる
    /// </summary>
    public class PackageConfigurationBatch : IConfigurationBatch
    {
        private readonly IFileInfoFacade _fileInfoFacade;

        public PackageConfigurationBatch(IFileInfoFacade fileInfoFacade)
        {
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public IConfiguration GetConfiguration()
        {
            // setting.jsonファイルコピー
            var settingFile = new FileInfo(Path.Combine(_fileInfoFacade.ApplicationLocation, _fileInfoFacade.AppSetting));
            if (!settingFile.Exists)
            {
                var settingFileDefualt = new FileInfo(Path.Combine(_fileInfoFacade.InstalledLocation, _fileInfoFacade.AppSetting));
                if (!settingFileDefualt.Exists) throw new FileNotFoundException(settingFileDefualt.FullName);
                File.Copy(settingFileDefualt.FullName, settingFile.FullName);
            }

            return new ConfigurationBuilder().SetBasePath(settingFile.DirectoryName).AddJsonFile(settingFile.Name).Build();
        }
    }
}
