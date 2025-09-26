using Eshop.RazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.DTOs
{
    public class OrderItemDto:BaseDto
    {
        public string ProductTitle { get; set; }
        public string ProductSlug { get; set; }
        public string ProductImageName { get; set; }
        public string ShopName { get; set; }
        public long OrderId { get; set; }
        public long InventoryId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Price * Count;
    }
}
