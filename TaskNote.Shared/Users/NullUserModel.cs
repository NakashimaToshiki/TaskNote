namespace TaskNote.Users
{
    public class NullUserModel : UserModel
    {
        public static NullUserModel Instance = new NullUserModel();

        protected NullUserModel() : base("")
        {
        }
    }
}
