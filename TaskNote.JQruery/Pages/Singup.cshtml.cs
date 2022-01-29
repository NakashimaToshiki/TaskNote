using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNote.Entity;

namespace TaskNote.JQruery.Pages
{
    public class SingupModel : PageModel
    {
        public UserModel UserInfo { get; set; } = new UserModel()
        {
            Id = "abc",
            Name = "‚È‚È‚µ",
            Password = "password",
            SexId = Sex.Female,
        };

        public void OnGet()
        {
        }
    }
}
