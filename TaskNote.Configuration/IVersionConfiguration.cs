namespace TaskNote.Configuration
{
    public interface IVersionConfiguration
    {
        string Load();

        void Save(string versionName);
    }
}
