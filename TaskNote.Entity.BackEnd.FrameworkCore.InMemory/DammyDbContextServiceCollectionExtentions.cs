using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public static class DammyDbContextServiceCollectionExtentions
    {
        public static IServiceCollection AddDammyDbContext(this IServiceCollection services) =>
            services
            .AddSingleton<IDbContextAddDammy, AddUserModelDammy>()
            .AddSingleton<IDbContextAddDammy, AddTaskModelDammy>()
            .AddTaskNoteDammy()
            ;
    }
}
