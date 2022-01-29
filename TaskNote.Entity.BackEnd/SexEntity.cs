using System.Collections.Generic;

namespace TaskNote.Entity
{
    public class SexEntity : SexModel, IEntity
    {
        public IList<UserEntity> UserEntities { get; set; } = new List<UserEntity>();
        public override string ToString() => this.ToStringProperties();
    }
}
