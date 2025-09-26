namespace Eshop.RazorPage.Models.Products.Command
{
    public class DeleteProductImageCommand
    {
        public long ProductId { get; set; }
        public long ImageId { get; set; }
    }
}
