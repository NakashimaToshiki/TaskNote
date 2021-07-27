namespace TaskNote.Configuration
{
    public interface IUserConfiguration
    {
        bool Load();

        void Save();
    }
}
