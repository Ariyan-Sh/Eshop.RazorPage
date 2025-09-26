namespace Eshop.RazorPage.Models.Sellers.Commmands
{
    public class EditSellerCommand
    {
        public long SellerId { get; set; }
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
        public SellerStatus Status { get; set; }
    }
}
