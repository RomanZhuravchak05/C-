using RestaurantManagementSystem.API.DTOs;

namespace RestaurantManagementSystem.API.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task CreateOrder(OrderDto orderDto);
        Task UpdateOrderStatus(int orderId, string status);
        Task<bool> DeleteOrder(int orderId);
    }
}