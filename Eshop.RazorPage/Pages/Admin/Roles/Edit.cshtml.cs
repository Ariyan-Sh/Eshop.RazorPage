using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Roles;
using Eshop.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Eshop.RazorPage.Pages.Admin.Roles
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IRoleService _roleService;

        public EditModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                return RedirectToPage("Index");
            }
            Title = role.Title;
            Permissions = role.Permissions;
            return Page();
        }

        public async Task<IActionResult> OnPost(long id, string title, List<Permission> permissions)
        {
            var result = await _roleService.EditRole(new EditRoleCommand() 
            {
                Id = id,
                Title = title,
                Permissions = permissions
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"), RedirectToPage("Edit", new { id }));
        }
    }
}
