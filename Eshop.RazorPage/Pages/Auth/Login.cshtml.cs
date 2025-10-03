using Eshop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Eshop.RazorPage.Models.Auth;

namespace Eshop.RazorPage.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "رمز عبور باید بیشتر از 5 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string RedirectTo { get; set; }
        public IActionResult OnGet(string redirectTo)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            RedirectTo = redirectTo;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Login(new LoginCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password
            });
            if(result.IsSuccess == false)
            {
                ModelState.AddModelError(nameof(PhoneNumber), result.MetaData.Message);
                return Page();
            }
            var token = result.Data.Token;
            var refreshToken = result.Data.RefreshToken;
            HttpContext.Response.Cookies.Append("token", token, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(7)
            });
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(10)
            });
            return Redirect("/");



            if(string.IsNullOrWhiteSpace(RedirectTo) == false)
            {
                return LocalRedirect(RedirectTo);
            }
            return Redirect("/");
        }
    }
}
