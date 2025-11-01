using Eshop.RazorPage.Models.Users;
using Eshop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Eshop.RazorPage.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        public UserDto CurrentUser { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Auth/Login?redirectTo=Profile");
            }

            CurrentUser = await _userService.GetCurrentUser();

            if(CurrentUser == null)
            {
                return Redirect("/Auth/Login?redirectTo=Profile");
            }
            return Page();
        }
    }
}
