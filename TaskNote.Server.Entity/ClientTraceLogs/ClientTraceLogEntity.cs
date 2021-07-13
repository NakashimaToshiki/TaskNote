using System;

namespace TaskNote.Server.Entity.ClientTraceLogs
{
    public class ClientTraceLogEntity : IEntity
    {
        public int Id { get; protected set; }

        public string UserId { get; protected set; }

        public byte[] Content { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public ClientTraceLogEntity()
        {

        }

        public ClientTraceLogEntity(string userId, byte[] context, DateTime createDate)
        {
            UserId = userId;
            Content = context;
            CreateDate = createDate;
        }

        public ClientTraceLogEntity(int id, string userId, byte[] context, DateTime createDate) : this(userId, context, createDate)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            Id = id;
        }
        public override string ToString() => this.ToStringProperties();
    }
}
