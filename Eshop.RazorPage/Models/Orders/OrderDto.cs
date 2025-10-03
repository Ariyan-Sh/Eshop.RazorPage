using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto:BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get; set; }
        public OrderAddress? Address { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime? LastUpdate { get; set; }

        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(s => s.TotalPrice);
                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                {
                    totalPrice -= Discount.DiscountAmount;
                }
                return totalPrice;
            }
        }
    }
}
