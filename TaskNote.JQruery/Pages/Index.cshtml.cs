using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;
using TaskNote.JQruery.Services;
using TaskNote.Options;

namespace TaskNote.JQruery.Pages
{
    public class TaskListModel : PageModel
    {
        private readonly ILogger<TaskListModel> _logger;

        public TaskListModel(ILogger<TaskListModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ICollection<TaskShortModel> TaskShorts { get; set; } = new List<TaskShortModel>()
        {
            NullTaskShortModel.Instance
        };

        public async Task<IActionResult> OnGetAsync([FromServices] TaskService taskService)
        {
          //  if (!ModelState.IsValid) return View(supplier);
            try
            {
                TaskShorts = await taskService.GetShortTasks();

                return Page();
            }
            catch (UserOptionException e)
            {
                _logger.LogInformation(e.Message);
                return RedirectToPage("/Login");
            }
        }

        
        public IActionResult OnPostAsync()
        {
            return RedirectToPage();
        }

        public IActionResult Search()
        {
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostSearchAsync()
        {
            return RedirectToPage();
        }
    }
}
