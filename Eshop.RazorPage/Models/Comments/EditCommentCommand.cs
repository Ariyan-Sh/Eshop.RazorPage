namespace Eshop.RazorPage.Models.Comments
{
    public class EditCommentCommand
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
    }
}


