using Common.Application.Validation.CustomValidation.IFormFile;
using Eshop.RazorPage.Models.Users;
using Eshop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Eshop.RazorPage.Models.Users.Commands;
using System.Threading.Tasks;
using Eshop.RazorPage.Infrastructure.RazorUtils;

namespace Eshop.RazorPage.Pages.Admin.Users
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Family { get; set; }
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "آواتار")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? Avatar { get; set; }
        public Gender Gender { get; set; }
        public async Task<IActionResult> OnGet(long userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return RedirectToPage("Index");
            }
            Name = user.Name;
            Family = user.Family;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            Gender = user.Gender;
            return Page();
        }

        public async Task<IActionResult> OnPost(long userId)
        {
            var result = await _userService.EditUser(new EditUserCommand()
            {
                Name = Name,
                Family = Family,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Avatar = Avatar,
                Gender = Gender,
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
