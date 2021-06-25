using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNote.WebServer.Controllers;

namespace TaskNote.WebServer.Pages
{
    public class TaskEditorModel : PageModel
    {
        private readonly TaskController _controller;

        public string UserName => RouteData.Values["username"].ToString();

        public int TaskId => (int)RouteData.Values["id"];

        public TaskEditorModel(TaskController controller)
        {
            this._controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public async Task<string> OnGet()
        {
            var a = await _controller.Get(UserName, TaskId);
            return a.ToString();
        }
    }
}
