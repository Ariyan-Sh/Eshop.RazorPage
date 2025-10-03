using Eshop.RazorPage.Models.Categories;

namespace Eshop.RazorPage.Models.Products
{
    public class ProductShopResult: BaseFilter<ProductShopDto,ProductShopFilterParam>
    {
        public CategoryDto? CategoryDto { get; set; }
    }
}
