namespace Eshop.RazorPage.Models.Comments
{
    public class AddCommentCommand
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string Text { get; set; }
    }
}


