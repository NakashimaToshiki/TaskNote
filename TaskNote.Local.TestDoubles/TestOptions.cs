namespace TaskNote
{
    public class TestOptions
    {
        public TestOptions(string name)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
        }

        public string Name { get; }
    }
}
