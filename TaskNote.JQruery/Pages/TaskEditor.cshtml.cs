using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNote.Entity.Sessions;
using TaskNote.JQruery.Services;
using TaskNote.Entity;

namespace TaskNote.JQruery.Pages
{
    public class TaskEditorModel : PageModel
    {
        public TaskModel Model { get; set; }

        public async Task OnGetAsync([FromServices] TaskService service, int id)
        {
            Model = await service.GetByIdAsync(id);
        }

        public async Task OnPostAsync([FromServices] ITaskSession session, TaskModel model) 
        {
            // 引数名がプロパティ名と同じであれば同一のものとみなされるらしい「Model」==「model」
            await session.PatchAsync(model);
        }

        public async Task<IActionResult> OnPostMethod([FromServices] ITaskSession session, [FromBody] TaskModel input)
        {
            var output = await session.PostAsync(input);
            return new OkResult();
        }
    }
}
