using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.DependencyInjection
{
    public static class TaskNoteServiceCollectionExtensions
    {
        public static IServiceCollection AddWpf(this IServiceCollection services)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseInMemoryDatabase("");
            services.AddSingleton<DbContextOptionsBuilder>();
            return services;
        }
    }
}
