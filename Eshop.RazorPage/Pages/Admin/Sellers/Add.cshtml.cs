using Eshop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Eshop.RazorPage.Models.Sellers.Commmands;
using Eshop.RazorPage.Infrastructure.RazorUtils;

namespace Eshop.RazorPage.Pages.Admin.Sellers
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ISellerService _sellerService;

        public AddModel(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public long UserId { get; set; }
        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string ShopName { get; set; }
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string NationalCode { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _sellerService.CreateSeller(new CreateSellerCommand()
            {
                UserId = UserId,
                ShopName = ShopName,
                NationalCode = NationalCode
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
