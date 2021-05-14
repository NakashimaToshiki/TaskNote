using System;
using System.IO;

namespace TaskNote
{
    public class TestFileInfoFacade : FileInfoFacade
    {
        private readonly TestOptions _options;

        public TestFileInfoFacade(TestOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override string InstalledLocation => Environment.CurrentDirectory;

        public override string ApplicationLocation => Path.Combine(Environment.CurrentDirectory, "Application");

        public override string Database => $"{_options.Name}.db";

        public override string NLog => "NLog.test.config";

        public override string AppSetting => "appsettings.test.json";

        public override FileInfo GetDatabaseFileInfo() => new FileInfo(Path.Combine(Environment.CurrentDirectory, "Database", Database));
    }
}
