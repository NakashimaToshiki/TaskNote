using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNote.Server.Models.Repositories;

namespace TaskNote.WebServer.Pages
{
    public class TaskListItemViewModel
    {
        public TaskListItemViewModel()
        {

        }
    }

    public class TaskListModel : PageModel
    {
        private readonly TaskRepository _repository;

        [BindProperty]
        public List<TaskListItemViewModel> ViewModels { get; private set; }

        public TaskListModel(TaskRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IActionResult> OnGetAsync(string username)
        {
            if (username is null)
            {
                return RedirectToPage("/Index");
            }

            var models = await _repository.GetByUserName(username);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username)
        {
            if (username is null)
            {
                return RedirectToPage("/Index");
            }

            await _repository.AddTask(username, "", "");

            return Page();
        }
    }
}
