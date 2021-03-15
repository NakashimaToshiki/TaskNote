using System;
using System.IO;

namespace TaskNote.Storage.BuiltIn
{
    public class StorageDirectoryOptions : IStorageDirectoryOptions
    {
        public string ApplicationPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskNote");

        public string InstalledLocation => Environment.CurrentDirectory;
    }
}
