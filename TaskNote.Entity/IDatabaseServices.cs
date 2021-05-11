using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity
{
    public interface IDatabaseServices
    {
        void Configure(IServiceCollection services);
    }
}
