namespace TaskNote.Entity
{
    public class TaskEntity : TaskModel, IEntity
    {
        public virtual UserEntity User { get; set; }

        public override string ToString() => this.ToStringProperties();
    }
}
