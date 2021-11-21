using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TaskNote.Entity;
using TaskNote.Http.Client;
using TaskNote.Storage;

namespace TaskNote.Models
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            services.
                UseTestOptions(new TestOptions(testName))
                ;

            var provider = services.BuildServiceProvider();

            return services.AddModelTest(provider.GetService<IDatabaseOptions>());
        }

        public static IServiceCollection AddModelTest(this IServiceCollection services, IDatabaseOptions databaseOptions)
        {
            return services
                .AddStorageTest()
                .AddDatabaseTest(databaseOptions)
                .AddHttpTest()
                .AddModel()
                ;
        }
    }
}
