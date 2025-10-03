using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Eshop.RazorPage.Models.Sellers.Commmands;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Eshop.RazorPage.Pages.SellerPanel.Inventories
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ISellerService _sellerService;

        public AddModel(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public long ProductId { get; set; }
        [Display(Name = "تعداد موجود")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Count { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(0, 100, ErrorMessage = "درصد تخفیف نامعتبر است")]
        public int PercentageDiscount { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var seller = await _sellerService.GetCurrentSeller();
            if(seller == null)
            {
                return Redirect("/");
            }
            var result = await _sellerService.AddInventory(new AddSellerInventoryCommand()
            {
                SellerId = seller.Id,
                ProductId = ProductId,
                Count = Count,
                Price = Price,
                PercentageDiscount = PercentageDiscount
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
