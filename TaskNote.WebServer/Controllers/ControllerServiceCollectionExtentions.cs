using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.WebServer.Controllers
{
    public static class ControllerServiceCollectionExtentions
    {
        public static IServiceCollection AddTaskNoteController(this IServiceCollection services)
        {
            return services
                .AddSingleton<TaskController>()
                ;
        }
    }
}
