using Microsoft.Extensions.DependencyInjection;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.FrameworkCore
{
    public static class EntityFrameworkCoreServiceCollectionExtentions
    {
        public static IServiceCollection AddTaskNoteDbContext<TDbContext>(this IServiceCollection services) where TDbContext : BaseContext =>
            services
            .AddDbContextFactory<TDbContext>()
            .AddSingleton<ITaskSession, TaskSession<TDbContext>>()
            .AddSingleton<IUserSession, UserSession<TDbContext>>()
        ;
    }
}
