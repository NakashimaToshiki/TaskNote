using System;

namespace TaskNote.Server.Entity.Users
{
    public class UserEntity : IEntity
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public UserEntity()
        {

        }

        public UserEntity(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string ToString() => this.ToStringProperties();
    }
}
