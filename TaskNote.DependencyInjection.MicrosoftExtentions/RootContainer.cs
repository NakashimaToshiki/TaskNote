using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.DependencyInjection.MicrosoftExtentions
{
    public class RootContainer : IContainer
    {
        public ServiceCollection Services { get; } = new ServiceCollection();

        public RootContainer()
        {
            IDbContext db;
#if DEBUG
            db = new DbMemoryContainer(Services);
#else
            db = new DbSqliteContainer(Services);
#endif
            Services.AddSingleton(db);
        }

        public virtual ServiceProvider BuildServiceProvider()
        {
            var ret = Services.BuildServiceProvider();
            return ret;
        }
    }
}
