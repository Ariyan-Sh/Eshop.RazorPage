using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Infrastructure.Utils;
using Eshop.RazorPage.Models.Comments;
using Eshop.RazorPage.Services.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Eshop.RazorPage.Pages.Admin.Comments
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ICommentService _commentService;

        public EditModel(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [Display(Name = "شناسه کاربر")]
        public long UserId { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public string CreationDate { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Text { get; set; }
        public async Task<IActionResult> OnGet(long commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            if (comment == null)
            {
                return RedirectToPage("Index");
            }
            Text = comment.Text;
            UserId = comment.UserId;
            CreationDate = comment.CreationDate.ToPersianDateTime();
            return Page();
        }

        public async Task<IActionResult> OnPost(long commentId)
        {
            var result = await _commentService.EditComment(new EditCommentCommand()
            {
                Text = Text
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
