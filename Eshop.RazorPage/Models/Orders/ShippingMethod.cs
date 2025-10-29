namespace Eshop.RazorPage.Models.Orders;

public class ShippingMethod
{
    public long Id { get; set; }
    public string ShippingType { get;  set; }
    public int ShippingCost { get;  set; }
}