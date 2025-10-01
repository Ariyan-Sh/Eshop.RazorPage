using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Comments;
using Eshop.RazorPage.Services.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Eshop.RazorPage.Pages.Admin.Comments
{
    public class IndexModel : BaseRazorFilter<CommentFilterParams>
    {
        private readonly ICommentService _commentService;

        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public CommentFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _commentService.GetCommentsByFilter(FilterParams);
        }

        public async Task<IActionResult> OnPostApprove(long id)
        {
            await _commentService.ChangeStatus(id, CommentStatus.Accepted);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostReject(long id)
        {
            await _commentService.ChangeStatus(id, CommentStatus.Rejected);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDelete(long id)
        {
            await _commentService.DeleteComment(id);
            return RedirectToPage();
        }

    }
}
