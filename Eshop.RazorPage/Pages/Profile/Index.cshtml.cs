using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.RazorPage.Pages.Profile
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Redirect("/Auth/Login?redirectTo=Profile");
                return;
            }
        }
    }
}
