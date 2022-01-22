using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskNote.JQruery.Pages
{
    public class SampleModel : PageModel
    {
        public void OnGet(string userid, string email)
        {
            Console.Write(userid);
        }

        public void OnPost(string userid, string email)
        {
            Console.Write(userid);
        }
    }

    public class Model
    {
        public string userid { get; set; }
        public string email { get; set; }
    }
}
