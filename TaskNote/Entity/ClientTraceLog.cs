using System;

namespace TaskNote.Entity
{
    public class ClientTraceLog : IDataClass
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public byte[] Content { get; set; }

        public DateTime CreateDate { get; set; }

        public override string ToString() => this.ToStringProperties();
    }
}
