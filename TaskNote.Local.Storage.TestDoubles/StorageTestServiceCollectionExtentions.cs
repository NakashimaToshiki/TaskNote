using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace TaskNote.Storage
{
    public static class StorageTestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            return services
                .UseTestOptions(new TestOptions(testName))
                .AddStorageTest()
                ;
        }

        public static IServiceCollection AddStorageTest(this IServiceCollection services)
        {
            return services.AddStorage<MockStorageServices>();
        }
    }
}
