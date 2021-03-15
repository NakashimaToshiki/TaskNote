using Microsoft.Extensions.FileProviders;

namespace TaskNote.Storage
{
    public interface IStorageFileInfo
    {
        IFileInfo NLog { get; }

        IFileInfo DefualtNLog { get; }

        IFileInfo AppSetting { get; }

        IFileInfo DefualtAppSetting { get; }
    }
}
