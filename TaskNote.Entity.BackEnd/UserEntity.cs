namespace TaskNote.Entity
{
    public class UserEntity : UserModel, IEntity
    {
        public override string ToString() => this.ToStringProperties();
    }
}
