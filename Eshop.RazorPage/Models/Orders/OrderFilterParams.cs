using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.DTOs
{
    public class OrderFilterParams:BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
