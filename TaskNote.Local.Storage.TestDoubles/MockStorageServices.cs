using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace TaskNote.Storage
{
    public class MockStorageServices : IStorageServices
    {
        public void Configure(IServiceCollection services)
        {
            services
                .AddSingleton<ILocalStorage>(_ => new Mock<ILocalStorage>().Object)
                ;
        }
    }
}
