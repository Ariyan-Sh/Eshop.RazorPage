using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Orders;
using Eshop.RazorPage.Models.Orders.Command;
using Shop.Query.Orders.DTOs;
using System.ComponentModel;

namespace Eshop.RazorPage.Services.Orders
{
    public interface IOrderService
    {
        Task<ApiResult> AddOrderItem(AddOrderItemCommand command);
        Task<ApiResult> CheckOutOrder(CheckOutOrderCommand command);
        Task<ApiResult> IncreaseOrderItem(IncreaseOrderItemCountCommand command);
        Task<ApiResult> DecreaseOrderItem(DecreaseOrderItemCountCommand command);
        Task<ApiResult> DeleteOrderItem(DeleteOrderItemCommand command);
        Task<ApiResult> SendOrder(long orderId);

        Task<OrderDto?> GetOrderById(long orderId);
        Task<OrderDto?> GetCurrentOrder();
        Task<OrderFilterResult> GetOrders(OrderFilterParams filterParams);
        Task<OrderFilterResult> GetUserOrders(int pageId, int take, OrderStatus? orderStatus);
        Task<List<ShippingMethod>> GetShippingMethods();
    }
}
