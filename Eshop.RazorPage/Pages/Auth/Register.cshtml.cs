using Eshop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Eshop.RazorPage.Models.Auth;
using Eshop.RazorPage.Infrastructure.RazorUtils;

namespace Eshop.RazorPage.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : BaseRazorPage
    {
        private IAuthService _authService;
        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5,ErrorMessage ="رمز عبور باید بیشتر از 5 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare("Password", ErrorMessage = "کلمه های عبور یکسان نیستند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Register(new RegisterCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            });
            return RedirectAndShowAlert(result, RedirectToPage("Login"));
        }
    }
}
