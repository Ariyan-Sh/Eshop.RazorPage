using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Roles;
using Eshop.RazorPage.Models.Users;
using Eshop.RazorPage.Services.Roles;
using Eshop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Eshop.RazorPage.Pages.Admin.Roles
{
    [BindProperties]
    public class AssignModel : BaseRazorPage
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public AssignModel(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "کد نقش")]
        [Required(ErrorMessage = "{0} نادرست است")]
        public long RoleId { get; set; }

        [Display(Name = "کد کاربری")]
        [Required(ErrorMessage = "{0} نادرست است")]
        public long UserId { get; set; }

        public string RoleTitle { get; set; } = "";

        public async Task OnGet()
        {
            var role = await _roleService.GetRoleById(RoleId);
            RoleTitle = role?.Title ?? "نامشخص";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _roleService.AssignRole(new AssignRoleCommand()
            {
                UserId = UserId,
                RoleId = RoleId,
            });

            if (result.IsSuccess)
            {
                return RedirectAndShowAlert(result, RedirectToPage("Assign", new { roleId = RoleId }));
            }

            return RedirectAndShowAlert(result, Page());
        }

        // متد جستجوی کاربران برای Select2
        public async Task<IActionResult> OnGetSearchUsersAsync(string query)
        {
            var data = await _userService.SearchUsersAsync(query, 20);
            return new JsonResult(data);
        }
    }
}
