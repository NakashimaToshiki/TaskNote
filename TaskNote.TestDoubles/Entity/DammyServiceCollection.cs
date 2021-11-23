using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Entity
{
    public static class DammyServiceCollection
    {
        public static IServiceCollection AddTaskNoteDammy(this IServiceCollection services) =>
            services
            .AddSingleton<UserModelDammy>()
            .AddSingleton<TaskModelDammy>()
            ;
    }
}
