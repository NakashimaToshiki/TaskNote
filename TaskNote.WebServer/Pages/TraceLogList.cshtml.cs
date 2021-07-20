using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskNote.WebServer.Pages
{
    public class ViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
    }

    public class TraceLogListModel : PageModel
    {
        public TraceLogListModel()
        {

        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(int user_id)
        {
            if (user_id <= 0)
            {
                return RedirectToPage("/Index");
            }

            return File()
        }
    }
}
