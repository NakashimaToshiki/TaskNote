﻿using Windows.Storage;

namespace TaskNote.Installer
{
    public class PackageFileInfoFacade : StorageFileInfo
    {
        public override string ApplicationLocation => ApplicationData.Current.LocalFolder.Path;

        public override string InstalledLocation => Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
    }
}
