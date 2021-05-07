using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Storage.BuiltIn
{
    public class BuiltInStorageServices : IStorageServices
    {
        public void Configure(IServiceCollection services) =>
            services
                .AddSingleton<IFileInfoFacade, StorageFileInfo>();
                //.AddSingleton<IStorageDirectory, StorageDirectory>()
                //.AddSingleton<IStorageDirectoryOptions, StorageDirectoryOptions>();
    }
}
