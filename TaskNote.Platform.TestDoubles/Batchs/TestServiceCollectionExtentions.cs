using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TaskNote.Platform.Batchs
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseBatchTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            services.UseTestOptions(new TestOptions(testName));

            var provider = services.BuildServiceProvider();

            return services.AddPlatformBatchTest(SynchronizationContext.Current, provider.GetService<IDatabaseOptions>());
        }

        public static IServiceCollection AddPlatformBatchTest(this IServiceCollection services, SynchronizationContext synchronization, IDatabaseOptions options)
        {
            return services
                .AddSingleton(synchronization)
                .AddPlatformBatch()
                .AddPlatformTest(synchronization, options)
                ;
        }
    }
}
