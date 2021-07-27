namespace TaskNote.Platform
{
    public interface IUserInfoView
    {
        bool? ShowDialog();

        void Close();

        UserInfoDialogResult Result { get; }
    }

    public enum UserInfoDialogResult
    {
        Cancel,
        OK,
    }
}
