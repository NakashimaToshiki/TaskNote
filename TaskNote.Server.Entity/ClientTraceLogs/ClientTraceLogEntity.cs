using System;
using TaskNote.Server.Entity.Users;

namespace TaskNote.Server.Entity.ClientTraceLogs
{
    public class ClientTraceLogEntity : IEntity
    {
        public int Id { get; protected set; }

        public int UserId { get; protected set; }

        public virtual UserEntity User { get; protected set; }

        public byte[] Content { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public ClientTraceLogEntity()
        {

        }

        public ClientTraceLogEntity(UserEntity user, byte[] context, DateTime createDate)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserId = User.Id;
            Content = context;
            CreateDate = createDate;
        }

        public ClientTraceLogEntity(int id, UserEntity user, byte[] context, DateTime createDate) : this(user, context, createDate)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            Id = id;
        }

        public override string ToString() => this.ToStringProperties();
    }
}
