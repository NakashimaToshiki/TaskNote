using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TaskNote.Configuration;

namespace TaskNote.WinRT
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

        public IConfigurationRoot GetConfiguration()
        {
            var fileInfo = _fileInfoFacade.GetAppSettingFileInfo();
            if (!fileInfo.Exists)
            {
                var defualtFileInfo = new FileInfo(Path.Combine(_fileInfoFacade.InstalledLocation, _fileInfoFacade.AppSetting));
                if (!defualtFileInfo.Exists) throw new FileNotFoundException(defualtFileInfo.FullName);
                if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
                File.Copy(defualtFileInfo.FullName, fileInfo.FullName);
            }

            return new ConfigurationBuilder().SetBasePath(fileInfo.DirectoryName).AddJsonFile(fileInfo.Name).Build();
        }
    }
}
