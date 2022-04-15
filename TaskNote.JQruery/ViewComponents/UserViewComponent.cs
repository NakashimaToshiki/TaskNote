using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskNote.JQruery.Pages;

namespace UserNote.JQruery.ViewComponents
{
    public enum UserViewComponentType
    {
        Default,
    }

    public class UserViewComponent : ViewComponent
    {
        public UserViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string prefix, UserViewComponentType type)
        {
            var model = new UserViewModel()
            {
                Prefix = prefix,
            };
            // 本来はサーバから取得
            model.UserId = "nanasi";
            model.Email = "nanasi@mail";
            return View(type.ToString(), model);
        }
    }
}
