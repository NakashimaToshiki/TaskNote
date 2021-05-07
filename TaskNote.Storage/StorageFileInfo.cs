using System;
using System.IO;

namespace TaskNote.Storage
{
    public class StorageFileInfo : IFileInfoFacade
    {

        public StorageFileInfo()
        {
        }

        public virtual string InstalledLocation => Environment.CurrentDirectory;

        public virtual string ApplicationPath => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public virtual string Database => "database.db";

        public virtual string NLog => "NLog.config";

        public virtual string AppSetting => "appsettings.json";

        public virtual string TraceLogFolder => "Logs";
    }
}
