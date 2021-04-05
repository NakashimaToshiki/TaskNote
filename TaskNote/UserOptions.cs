namespace TaskNote
{
    public interface IUserOptions
    {
        string UserId { get; }

        string Password { get; }
    }

    public class UserOptions : IUserOptions
    {
        public string UserId { get; set; }

        public string Password { get; set; }
    }
}
