namespace TaskNote.Platform
{
    public class SpyUserInfoView : IUserInfoView
    {
        public UserInfoDialogResult Result { get; set; } = UserInfoDialogResult.OK;

        public int CloseCount { get; private set; } = 0;

        public void Close()
        {
            CloseCount++;
        }

        public int ShowDialogCount { get; private set; } = 0;

        public bool? ShowDialog()
        {
            ShowDialogCount++;
            return true;
        }
    }
}
