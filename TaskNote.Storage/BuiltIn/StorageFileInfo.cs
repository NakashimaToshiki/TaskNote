using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using System;
using System.IO;

namespace TaskNote.Storage.BuiltIn
{
    public class StorageFileInfo : IFileInfoFacade
    {
        private readonly IStorageDirectoryOptions options;

        public StorageFileInfo(IStorageDirectory directory, IStorageDirectoryOptions options)
        {
            if (directory is null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            NLog = new PhysicalFileInfo(new FileInfo(Path.Combine(options.ApplicationPath, "NLog.config")));
            DefualtNLog = new PhysicalFileInfo(new FileInfo(Path.Combine(options.InstalledLocation, "NLog.config")));
            AppSetting = new PhysicalFileInfo(new FileInfo(Path.Combine(options.ApplicationPath, "appsettings.json")));
            DefualtAppSetting = new PhysicalFileInfo(new FileInfo(Path.Combine(options.InstalledLocation, "appsettings.json")));
        }

        public IFileInfo NLog { get; private set; }

        public IFileInfo DefualtNLog { get; private set; }

        public IFileInfo AppSetting { get; private set; }

        public IFileInfo DefualtAppSetting { get; private set; }
    }
}
