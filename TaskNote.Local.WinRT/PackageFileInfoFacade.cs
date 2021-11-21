using Windows.Storage;

namespace TaskNote.WinRT
{
    public class PackageFileInfoFacade : FileInfoFacade
    {
        public override string ApplicationLocation => ApplicationData.Current.LocalFolder.Path;

        public override string InstalledLocation => Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
    }
}
