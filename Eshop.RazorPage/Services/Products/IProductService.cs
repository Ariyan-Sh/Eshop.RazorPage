using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Products;
using Eshop.RazorPage.Models.Products.Command;

namespace Eshop.RazorPage.Services.Products
{
    public interface IProductService
    {
        Task<ApiResult> CreateProduct(CreateProductCommand command);
        Task<ApiResult> AddImage(AddProductImageCommand command);
        Task<ApiResult> EditProduct(EditProductCommand command);
        Task<ApiResult> DeleteProductImage(DeleteProductImageCommand command);

        Task<ProductDto?> GetProductById(long productId);
        Task<ProductDto?> GetProductBySlug(string slug);
        Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams);
    }
}
