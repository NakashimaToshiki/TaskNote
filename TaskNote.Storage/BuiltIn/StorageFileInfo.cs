using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using System;
using System.IO;

namespace TaskNote.Storage.BuiltIn
{
    public class StorageFileInfo : IStorageFileInfo
    {
        private readonly IStorageDirectory _directory;
        private readonly IStorageDirectoryOptions _options;

        public StorageFileInfo(IStorageDirectory directory, IStorageDirectoryOptions options)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            NLog = new PhysicalFileInfo(new FileInfo(Path.Combine(_options.ApplicationPath, "NLog.config")));
            DefualtNLog = new PhysicalFileInfo(new FileInfo(Path.Combine(_options.InstalledLocation, "NLog.config")));
            AppSetting = new PhysicalFileInfo(new FileInfo(Path.Combine(_options.ApplicationPath, "appsettings.json")));
            DefualtAppSetting = new PhysicalFileInfo(new FileInfo(Path.Combine(_options.InstalledLocation, "appsettings.json")));
        }

        public IFileInfo NLog { get; private set; }

        public IFileInfo DefualtNLog { get; private set; }

        public IFileInfo AppSetting { get; private set; }

        public IFileInfo DefualtAppSetting { get; private set; }
    }
}
