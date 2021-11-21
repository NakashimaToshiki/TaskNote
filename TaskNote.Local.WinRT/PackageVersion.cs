using Windows.ApplicationModel;

namespace TaskNote.WinRT
{
    public class PackageVersion : IVersion
    {
        public int Major => Package.Current.Id.Version.Major;

        public int Minor => Package.Current.Id.Version.Minor;

        public int Build => Package.Current.Id.Version.Build;

        public int Revision => Package.Current.Id.Version.Revision;

        public string AppName => Package.Current.DisplayName;
    }
}
