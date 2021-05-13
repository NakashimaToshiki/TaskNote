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

        string Database { get; }

        string NLog { get; }

        string AppSetting { get; }

        string TraceLogFolder { get; }
    }

    public class StorageFileInfo : IFileInfoFacade
    {

        public StorageFileInfo()
        {
        }

        public virtual string InstalledLocation => Environment.CurrentDirectory;

        public virtual string ApplicationLocation => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskNote");

        public virtual string Database => "database.db";

        public virtual string NLog => "NLog.config";

        public virtual string AppSetting => "appsettings.json";

        public virtual string TraceLogFolder => "Logs";
    }
}
