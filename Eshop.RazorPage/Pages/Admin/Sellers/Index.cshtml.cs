using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Sellers;
using Eshop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Eshop.RazorPage.Pages.Admin.Sellers
{
    public class IndexModel : BaseRazorFilter<SellerFilterParams>
    {
        private readonly ISellerService _sellerService;

        public IndexModel(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public SellerFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _sellerService.GetSellersByFilter(FilterParams);
        }
    }
}
