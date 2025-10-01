using Eshop.RazorPage.Infrastructure;
using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Comments;

namespace Eshop.RazorPage.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _client;

        public CommentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> ChangeStatus(long commentId, CommentStatus status)
        {
            var result = await _client.PutAsJsonAsync("api/comment/changeStatus", new { id = commentId, status });
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> AddComment(AddCommentCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/comment", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteComment(long commentId)
        {
            var content = await _client.DeleteAsync($"api/comment/{commentId}");
            var result = await content.Content.ReadFromJsonAsync<ApiResult>();
            return result;
        }

        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            var result = await _client.PutAsJsonAsync("api/comment", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<CommentDto?> GetCommentById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CommentDto>>($"api/comment/{id}");
            return result?.Data;
        }

        public async Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams)
        {
            var url = filterParams.GenerateBaseFilterUrl("api/comment");
            if(filterParams.UserId != null)
            {
                url += $"&UserId={filterParams.UserId}";
            }
            if (filterParams.ProductId != null)
            {
                url += $"&ProductId={filterParams.ProductId}";
            }
            if (filterParams.Status != null)
            {
                url += $"&CommentStatus={filterParams.Status}";
            }
            if (filterParams.StartDate != null)
            {
                url += $"&StartDate={filterParams.StartDate}";
            }
            if (filterParams.EndDate != null)
            {
                url += $"&EndDate={filterParams.EndDate}";
            }
            var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
            return result?.Data;
        }

        public async Task<CommentFilterResult> GetProductComments(int pageId, int take, long productId)
        {
            var url = $"api/comment/productComments?pageId={pageId}&take={take}&productId={productId}";
            var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
            return result?.Data;
        }
    }
}
