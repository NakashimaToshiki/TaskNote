using System;
using TaskNote.Users;

namespace TaskNote.BackEnd.Entity.Users
{
    public class UserEntity : UserModel, IEntity
    {

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
