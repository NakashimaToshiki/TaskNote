using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Server.Models.TraceLogs
{
    public class TraceLogModelFractory
    {
        private readonly IDateTimeOptions _date;

        public TraceLogModelFractory(IDateTimeOptions date)
        {
            this._date = date ?? throw new ArgumentNullException(nameof(date));
        }
    }
}
