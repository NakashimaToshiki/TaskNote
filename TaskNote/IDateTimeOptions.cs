using System;

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
}
