namespace TaskNote
{
    public class DummyVersion : IVersion
    {
        public DummyVersion()
        {

        }

        public int Major { get; set; } = 1;

        public int Minor { get; set; } = 0;

        public int Build { get; set; } = 0;

        public int Revision { get; set; } = 0;

        public string AppName { get; set; } = "TestAppName";
    }
}
