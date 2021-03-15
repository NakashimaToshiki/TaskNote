namespace TaskNote.Logging
{
    public interface ILoggerOptions
    {
        string LoggerFolder { get; }
    }

    public class LoggerOptions : ILoggerOptions
    {
        public string LoggerFolder { get; }
    }
}
