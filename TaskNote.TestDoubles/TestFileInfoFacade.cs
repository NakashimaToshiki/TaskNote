using System;
using System.IO;

namespace TaskNote
{
    public class TestFileInfoFacade : IFileInfoFacade
    {
        private readonly TestOptions _testName;

        public TestFileInfoFacade(TestOptions testName)
        {
            _testName = testName ?? throw new ArgumentNullException(nameof(testName));
        }

        public virtual string InstalledLocation => Environment.CurrentDirectory;

        public virtual string ApplicationPath => Path.Combine(Environment.CurrentDirectory, "ApplicationPath");

        public string Database => $"{_testName.Name}.db";

        public virtual string NLog => "NLog.test.config";

        public virtual string AppSetting => "appsettings.test.json";

        public virtual string TraceLogFolder => "Logs"; // 未使用
    }
}
