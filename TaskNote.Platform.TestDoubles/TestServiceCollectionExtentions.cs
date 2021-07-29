using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Threading;
using TaskNote.Models;

namespace TaskNote.Platform
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            services
                .UseTestOptions(new TestOptions(testName))
                ;

            var databaseOptions = services.BuildServiceProvider().GetService<IDatabaseOptions>();

            return services
                .AddPlatformTest(SynchronizationContext.Current, databaseOptions);
        }

        public static IServiceCollection AddPlatformTest(this IServiceCollection services, SynchronizationContext synchronization, IDatabaseOptions options)
        {
            return services
                .AddPlatform<MockPlatformServices>(synchronization)
                .AddModelTest(options)
                ;
        }
    }
}
