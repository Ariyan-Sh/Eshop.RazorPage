using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Orders;
using Eshop.RazorPage.Models.Orders.Command;
using Shop.Query.Orders.DTOs;

namespace Eshop.RazorPage.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/order", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> CheckOutOrder(CheckOutOrderCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/order/Checkout", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DecreaseOrderItem(DecreaseOrderItemCountCommand command)
        {
            var result = await _client.PutAsJsonAsync("api/order/orderItem/DecreaseCount", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteOrderItem(DeleteOrderItemCommand command)
        {
            var result = await _client.DeleteAsync($"api/order/orderItem/{command.OrderItemId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<OrderDto?> GetCurrentOrder()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<OrderDto>?>($"api/order/current/");
            return result?.Data;
        }

        public async Task<OrderDto?> GetOrderById(long orderId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<OrderDto>?>($"api/order/{orderId}");
            return result?.Data;
        }

        public async Task<OrderFilterResult> GetOrders(OrderFilterParams filterParams)
        {
            var url = $"api/order/?pageId={filterParams.PageId}&take={filterParams.Take}";
            if (filterParams.StartDate != null)
                url += "&startDate=" + filterParams.StartDate;

            if (filterParams.EndDate != null)
                url += "&endDate=" + filterParams.EndDate;

            if (filterParams.Status != null)
                url += "&status=" + filterParams.Status;

            if (filterParams.UserId != null)
                url += "&UserId=" + filterParams.UserId;

            var result = await _client.GetFromJsonAsync<ApiResult<OrderFilterResult>>(url);
            return result?.Data;
        }

        public async Task<List<ShippingMethod>> GetShippingMethods()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<ShippingMethod>>>("api/shippingmethod");
            return result?.Data ?? new List<ShippingMethod>();
        }

        public async Task<OrderFilterResult> GetUserOrders(int pageId, int take, OrderStatus? orderStatus)
        {
            var url = $"api/order/current/filter?pageId={pageId}&take={take}";
            if (orderStatus != null)
                url += $"&status={orderStatus}";
            var result = await _client
                .GetFromJsonAsync<ApiResult<OrderFilterResult>>(url);
            return result?.Data;
        }

        public async Task<ApiResult> IncreaseOrderItem(IncreaseOrderItemCountCommand command)
        {
            var result = await _client.PutAsJsonAsync("api/order/orderItem/IncreaseCount", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SendOrder(long orderId)
        {
            var result = await _client.PutAsync($"api/order/SendOrder/{orderId}",null);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
