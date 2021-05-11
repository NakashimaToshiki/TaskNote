using System;
using System.Diagnostics;

namespace TaskNote
{
    public class StopwatchDatetimeOptions : Stopwatch, IDateTimeOptions
    {
        public DateTime Offset { get; set; } = DateTime.MinValue;

        public DateTime Now => Offset + TimeSpan.FromMilliseconds(ElapsedMilliseconds);

        public StopwatchDatetimeOptions()
        {
        }
    }
}
