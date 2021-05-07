using Windows.Storage;

namespace TaskNote.Storage.Packege
{
    public class PackegeFileInfoFacade : StorageFileInfo
    {
        public override string ApplicationPath => ApplicationData.Current.LocalFolder.Path;

        public override string InstalledLocation => Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
    }
}
