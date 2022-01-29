using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNote.Entity;

namespace TaskNote.JQruery.Pages
{
    public class SingupResultModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(UserModel userInfo)
        {
            return Page();
        }
    }
}
