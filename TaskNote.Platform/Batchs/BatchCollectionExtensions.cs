using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Platform.Batchs
{
    public static class BatchCollectionExtensions
    {
        public static IServiceCollection AddPlatformBatch(this IServiceCollection services)
        {
            return services
                .AddSingleton<MainStartBatch>()
                .AddSingleton<MainExitBatch>()
                .AddSingleton<StartupWindowBatch>()
                .AddSingleton<StorageMigrateBatch>()
                .AddSingleton<LoginIntialBatch>()
                .AddSingleton<UserLoginBatch>()
                .AddSingleton<IStartBatch>(_ => _.GetService<MainStartBatch>())
                .AddSingleton<IExitBatch>(_ => _.GetService<MainExitBatch>());
        }
    }
}
