using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Storage
{
    public interface IStorageServices
    {
        void Configure(IServiceCollection services);
    }
}
