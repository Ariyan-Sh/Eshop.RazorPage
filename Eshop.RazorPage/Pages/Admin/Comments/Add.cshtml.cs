using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Services.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Eshop.RazorPage.Pages.Admin.Comments
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ICommentService _commentService;

        public AddModel(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public long UserId { get; set; }
        [Display(Name = "شناسه محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public long ProductId { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Text { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _commentService.AddComment(new Models.Comments.AddCommentCommand()
            {
                UserId = UserId,
                ProductId = ProductId,
                Text = Text
            });
                return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
