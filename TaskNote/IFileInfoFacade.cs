using System;
using System.IO;

namespace TaskNote
{
    public interface IFileInfoFacade
    {
        /// <summary>
        /// インストールローカルディレクトリ
        /// </summary>
        string InstalledLocation { get; }

        /// <summary>
        /// アプリケーションディレクトリ
        /// </summary>
        string ApplicationLocation { get; }

        string TraceLogFolder { get; }

        string Database { get; }

        string NLog { get; }

        string AppSetting { get; }

        DirectoryInfo GetApplicationDirectoryInfo();

        DirectoryInfo GetTraceLogDirectoryInfo();

        FileInfo GetDatabaseFileInfo();

        FileInfo GetNLogFileInfo();

        FileInfo GetAppSettingFileInfo();
    }

    public class FileInfoFacade : IFileInfoFacade
    {

        public FileInfoFacade()
        {
        }

        public virtual string InstalledLocation => Environment.CurrentDirectory;

        public virtual string ApplicationLocation => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskNote");

        public virtual string TraceLogFolder => "Logs";

        public virtual string Database => "database.db";

        public virtual string NLog => "NLog.config";

        public virtual string AppSetting => "appsettings.json";

        public DirectoryInfo GetApplicationDirectoryInfo() => new DirectoryInfo(ApplicationLocation);

        public virtual DirectoryInfo GetTraceLogDirectoryInfo() => new DirectoryInfo(Path.Combine(ApplicationLocation, TraceLogFolder));

        public virtual FileInfo GetDatabaseFileInfo() => new FileInfo(Path.Combine(ApplicationLocation, Database));

        public virtual FileInfo GetNLogFileInfo() => new FileInfo(Path.Combine(InstalledLocation, NLog));

        public virtual FileInfo GetAppSettingFileInfo() => new FileInfo(Path.Combine(InstalledLocation, AppSetting));
    }
}
