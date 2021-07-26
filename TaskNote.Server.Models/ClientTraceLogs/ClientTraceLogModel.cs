using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Server.Models.ClientTraceLogs
{
    public class ClientTraceLogModel : IModel
    {
        public int Id { get; }
        public DateTime Time { get; }

        public ClientTraceLogModel(int id, DateTime time)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            Id = id;
            Time = time;
        }
    }
}
