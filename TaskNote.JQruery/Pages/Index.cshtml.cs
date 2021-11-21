using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.ApiClient;
using TaskNote.Entity;

namespace TaskNote.JQruery.Pages
{
    public class TaskListModel : PageModel
    {
        private readonly ITaskShortsApiClient _apiClient;
        
        public TaskListModel(ITaskShortsApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public ICollection<TaskShortModel> TaskShorts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            TaskShorts = await _apiClient.GetTaskShortsResponseAsync(DateTime.MinValue, DateTime.Now);

            if (TaskShorts == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            return RedirectToPage();
        }
    }
}
