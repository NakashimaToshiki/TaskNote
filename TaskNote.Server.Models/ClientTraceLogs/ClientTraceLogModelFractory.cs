using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Server.Models.ClientTraceLogs
{
    public class ClientTraceLogModelFractory
    {
        private readonly IDateTimeOptions _date;

        public ClientTraceLogModelFractory(IDateTimeOptions date)
        {
            _date = date ?? throw new ArgumentNullException(nameof(date));
        }
    }
}
