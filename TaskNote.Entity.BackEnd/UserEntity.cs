using System.Collections.Generic;

namespace TaskNote.Entity
{
    public class UserEntity : UserModel, IEntity
    {
        public virtual List<TaskEntity> Tasks { get; set; }

        public SexEntity SexEntity { get; set; } 

        public override string ToString() => this.ToStringProperties();
    }
}
