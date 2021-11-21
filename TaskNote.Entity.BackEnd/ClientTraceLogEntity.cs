using TaskNote.Entity;

namespace TaskNote.BackEnd.Entity.ClientTraceLogs
{
    public class ClientTraceLogEntity : ClientTraceLog, IEntity
    {
        public virtual UserEntity User { get; set; }

        public override string ToString() => this.ToStringProperties();
    }
}
