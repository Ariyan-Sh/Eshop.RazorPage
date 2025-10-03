using Eshop.RazorPage.Models.Users;
using Eshop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Eshop.RazorPage.Models.Users.Commands;
using Eshop.RazorPage.Infrastructure.RazorUtils;

namespace Eshop.RazorPage.Pages.Admin.Users
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public AddModel(IUserService userService)
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
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Password { get; set; }
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public Gender Gender { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _userService.CreateUser(new CreateUserCommand()
            {
                Name = Name,
                Family = Family,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Password = Password,
                Gender = Gender
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
