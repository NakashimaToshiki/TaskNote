using Microsoft.Extensions.DependencyInjection;
using TaskNote.Batch;
using TaskNote.Database;
using TaskNote.Database.EntityFramework.InMemory;
using TaskNote.Platform;

namespace TaskNote.TestDoubles
{
    public static class TestDoublesCollectionExtensions
    {
        public static IServiceCollection AddTestDoubles(this IServiceCollection services) =>
            services
                .AddDatabase<InMemoryDatabaseServices>()
                .AddPlatform<MockPlatformServices>()
                .AddBatch();
    }
}
