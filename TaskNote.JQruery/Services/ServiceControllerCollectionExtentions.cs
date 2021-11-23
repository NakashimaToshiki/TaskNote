using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.JQruery.Services
{
    public static class ServiceControllerCollectionExtentions
    {
        public static IServiceCollection AddTaskNoteServiceControllers(this IServiceCollection services) =>
            services
            .AddSingleton<TaskService>()
            ;
    }
}
