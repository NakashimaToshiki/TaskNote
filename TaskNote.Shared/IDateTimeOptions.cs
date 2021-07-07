using System;
using System.Diagnostics;

namespace TaskNote
{
    public interface IDateTimeOptions : IDataClass
    {
        DateTime Now { get; }
    }

    public class DateTimeOptions : IDateTimeOptions
    {
        public DateTime Now => DateTime.Now;

        public override string ToString() => this.ToStringProperties();
    }

    public class StopwatchDatetimeOptions : Stopwatch, IDateTimeOptions
    {
        public DateTime Offset { get; set; } = DateTime.MinValue;

        public DateTime Now => Offset + TimeSpan.FromMilliseconds(ElapsedMilliseconds);

        public override string ToString() => this.ToStringProperties();

        public StopwatchDatetimeOptions()
        {

        }
    }
}
