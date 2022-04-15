using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;
using TaskNote.JQruery.Services;
using TaskNote.Options;
using System.Linq;

namespace TaskNote.JQruery.Pages
{
    public class UserModel
    {
        public string UserId { get; set; }

        public string Email { get; set; }
    }

    public class UserViewModel : UserModel
    {
        public string Prefix { get; set; }
    }

    public class TaskListModel : PageModel
    {
        private readonly ILogger<TaskListModel> _logger;

        public IList<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){UserId = "susuki", Email="susuki@mail" },
            new UserModel(){UserId = "tanaka", Email="tanaka@mail" },
        };

        public UserViewModel UserA { get; set; } = new UserViewModel()
        {
            Prefix = nameof(UserA),
            UserId = "hirosi",
            Email = "hirosi@mail",
        };
        public UserViewModel UserB { get; set; } = new UserViewModel()
        {
            Prefix= nameof(UserB),
            UserId = "tadasi",
            Email = "tadasi@mail",
        };


        public TaskListModel(ILogger<TaskListModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> OnGetAsync(UserModel model)
        {
            try
            {
                return Page();
            }
            catch (UserOptionException e)
            {
                _logger.LogInformation(e.Message);
                return RedirectToPage("/Login");
            }
        }

        public IActionResult OnPostAsync(Response response)
        {
            return RedirectToPage();
        }

        /*
        public IActionResult OnPostAsync(IList<UserModel> users)
        {
            return RedirectToPage();
        }*/
    }

    public class Response {
        public UserModel UserA { get; set; }
        public UserModel UserB {get;set;}
    }
}
