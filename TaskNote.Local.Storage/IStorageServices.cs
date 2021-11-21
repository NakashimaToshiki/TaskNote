using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Storage
{
    public interface IStorageServices
    {
        void Configure(IServiceCollection services);
    }

    public class StorageServices : IStorageServices
    {
        public void Configure(IServiceCollection services) =>
            services
            .AddSingleton<ILocalStorage, LocalStorage>()
            ;
    }
}
