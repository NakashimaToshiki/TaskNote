using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNote.Server.Models.Repositories;

namespace TaskNote.WebServer.Pages
{
    public class TraceLogListViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
    }

    public class TraceLogListModel : PageModel
    {
        private readonly ClientTraceLogRepository _repository;

        public TraceLogListModel(ClientTraceLogRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [BindProperty]
        public IReadOnlyList<TraceLogListViewModel> ViewModels { get; private set; }

        public void OnGet()
        {
        }

        /*
        public async Task<IActionResult> OnPostAsync(int user_id)
        {
            if (user_id <= 0)
            {
                return RedirectToPage("/Index");
            }

            ViewModels = await _repository.
                )
            return File()
        }*/
    }
}
