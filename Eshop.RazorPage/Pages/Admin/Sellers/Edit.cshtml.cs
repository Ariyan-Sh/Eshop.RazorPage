using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Sellers;
using Eshop.RazorPage.Models.Sellers.Commmands;
using Eshop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Eshop.RazorPage.Pages.Admin.Sellers
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ISellerService _sellerService;

        public EditModel(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string ShopName { get; set; }
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string NationalCode { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public SellerStatus Status { get; set; }
        public async Task<IActionResult> OnGet(long sellerId)
        {
            var seller = await _sellerService.GetSellerById(sellerId);
            if (seller == null)
            {
                return RedirectToPage("Index");
            }
            ShopName = seller.ShopName;
            NationalCode = seller.NationalCode;
            Status = seller.Status;
            return Page();
        }

        public async Task<IActionResult> OnPost(long sellerId)
        {
            var result = await _sellerService.EditSeller(new EditSellerCommand()
            {
                SellerId = sellerId,
                ShopName = ShopName,
                NationalCode = NationalCode,
                Status = Status
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
