using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;

namespace TaskNote.JQruery.ViewComponents
{
    public enum TaskViewComponentType
    {
        Default,
    }

    public class TaskViewComponent : ViewComponent
    {
        private readonly ITaskSession _session;

        public TaskViewComponent(ITaskSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async Task<IViewComponentResult> InvokeAsync(string prefix, int id, TaskViewComponentType viewType)
        {
            var item = await _session.GetByIdAsync(id);
            return View(viewType.ToString(), item);
        }
    }
}
