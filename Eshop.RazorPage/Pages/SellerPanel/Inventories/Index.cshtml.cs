using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Sellers;
using Eshop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Eshop.RazorPage.Models.Sellers.Commmands;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.RazorPage.Pages.SellerPanel.Inventories
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ISellerService _sellerService;
        private IRenderViewToString _renderViewToString;

        public IndexModel(ISellerService sellerService, IRenderViewToString renderViewToString)
        {
            _sellerService = sellerService;
            _renderViewToString = renderViewToString;
        }
        public List<InventoryDto> Inventories { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var seller = await _sellerService.GetCurrentSeller();
            if (seller == null)
            {
                return Redirect("/");
            }
            Inventories = await _sellerService.GetSellerInventories();
            return Page();
        }

        public async Task<IActionResult> OnGetEditPage(long inventoryId)
        {
            return await AjaxTryCatch(async () =>
            {
                var inventory = await _sellerService.GetInventoryById(inventoryId);
                if (inventory == null)
                {
                    return ApiResult<string>.Success("اطلاعات نامعتبر است");
                }
                var view = await _renderViewToString.RenderToStringAsync("_Edit", new EditSellerInventoryCommand()
                {
                    SellerId = inventory.SellerId,
                    InventoryId = inventory.Id,
                    Count = inventory.Count,
                    Price = inventory.Price,
                    DicountPercentage = inventory.DiscountPercentage
                },PageContext);
                return ApiResult<string>.Success(view);
            });
        }

        public async Task<IActionResult> OnPost(EditSellerInventoryCommand command)
        {
            return await AjaxTryCatch(() => _sellerService.EditInventory(command));
        }
    }
}
