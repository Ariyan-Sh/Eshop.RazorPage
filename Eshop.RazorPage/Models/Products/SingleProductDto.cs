using Eshop.RazorPage.Models.Sellers;

namespace Eshop.RazorPage.Models.Products
{
    public class SingleProductDto
    {
        public ProductDto ProductDto { get; set; }
        public List<InventoryDto> Inventories { get; set; }
    }
}
