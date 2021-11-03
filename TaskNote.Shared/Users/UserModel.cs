using System;
using TaskNote;

namespace TaskNote.Users
{
    public class UserModel : IDataClass
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public UserModel()
        {

        }

        public UserModel(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string ToString() => this.ToStringProperties();
    }
}
