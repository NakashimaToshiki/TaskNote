using System;
using TaskNote.Shared;

namespace TaskNote
{
    public interface IDateTimeOptions : IDataClass
    {
        DateTime Now { get; }
    }

    public class DateTimeOptions : IDateTimeOptions
    {
        public DateTime Now => DateTime.Now;
    }

    public class StopwatchDatetimeOptions : System.Diagnostics.Stopwatch, IDateTimeOptions
    {
        public DateTime Offset { get; set; } = DateTime.MinValue;

        public DateTime Now => Offset + TimeSpan.FromMilliseconds(ElapsedMilliseconds);

        public StopwatchDatetimeOptions()
        {
        }
    }
}
