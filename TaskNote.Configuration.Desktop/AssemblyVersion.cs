using System.Diagnostics;
using System.Reflection;

namespace TaskNote.Configuration.Desktop
{
    public class AssemblyVersion : IVersion
    {
        private readonly FileVersionInfo _info;

        public AssemblyVersion()
        {
            _info = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
        }

        public int Major => _info.FileMajorPart;

        public int Minor => _info.FileMinorPart;

        public int Build => _info.FileBuildPart;

        public int Revision => _info.FilePrivatePart;

        public string AppName => _info.FileName;
    }
}
