namespace TaskNote.Server.Entity.Users
{
    public class NullUserEntity : UserEntity
    {
        public static NullUserEntity Instance = new NullUserEntity();

        protected NullUserEntity() : base("")
        {
        }
    }
}
