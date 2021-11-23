using Microsoft.Extensions.DependencyInjection;
using TaskNote.Options;

namespace TaskNote.Services
{
    public static class AspNetServiceCollectionExtentions
    {
        public static IServiceCollection AddTaskNoteAspNetServices(this IServiceCollection services) =>
            services
            .AddHttpContextAccessor()
            .AddSingleton<IUserOptions, UserOption>()
            ;
    }
}
