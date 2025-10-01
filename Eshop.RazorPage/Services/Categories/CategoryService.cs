using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Categories;

namespace Eshop.RazorPage.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> AddChildCategory(AddChildCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/category/AddChild", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/category", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteCategory(long categoryId)
        {
            var result = await _client.DeleteAsync($"api/category/{categoryId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _client.PutAsJsonAsync("api/category", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<CategoryDto>>>($"api/category");
            return result?.Data;
        }

        public async Task<CategoryDto?> GetCategoryById(long categoryId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CategoryDto>>($"api/category/{categoryId}");
            return result?.Data;
        }

        public async Task<List<ChildCategoryDto>> GetChild(long parentCategoryId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<ChildCategoryDto>>>($"api/category/getChild/{parentCategoryId}");
            return result?.Data;
        }
    }
}
