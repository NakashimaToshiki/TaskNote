namespace TaskNote
{
    public interface IDatabaseOptions
    {
        string Type { get; }
    }

    public class DatabaseOptions : IDatabaseOptions
    {
        public string Type { get; set; }
    }
}
