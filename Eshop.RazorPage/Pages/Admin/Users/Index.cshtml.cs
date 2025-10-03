using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Users;
using Eshop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Eshop.RazorPage.Pages.Admin.Users
{
    public class IndexModel : BaseRazorFilter<UserFilterParams>
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        public UserFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _userService.GetUsersByFilter(FilterParams);
        }
    }
}
