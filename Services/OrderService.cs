using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.API.Data;
using RestaurantManagementSystem.API.DTOs;
using RestaurantManagementSystem.API.Models;

namespace RestaurantManagementSystem.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly HashSet<string> _allowedStatuses = new() { "New", "InProgress", "Completed", "Cancelled" };

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.OrderMenuItems)
                .Select(order => new OrderDto
                {
                    Id = order.Id,
                    TableId = order.TableId,
                    Status = order.Status,
                    MenuItemIds = order.OrderMenuItems.Select(omi => omi.MenuItemId).ToList()
                })
                .ToListAsync();
        }

        public async Task CreateOrder(OrderDto orderDto)
        {
            var status = string.IsNullOrEmpty(orderDto.Status) ? "New" : orderDto.Status;

            if (!_allowedStatuses.Contains(status))
                throw new ArgumentException($"Недопустимий статус: {status}");

            var order = new Order
            {
                TableId = orderDto.TableId,
                Status = status,
                OrderDate = DateTime.UtcNow,
                OrderMenuItems = new List<OrderMenuItem>()
            };

            foreach (var menuItemId in orderDto.MenuItemIds)
            {
                order.OrderMenuItems.Add(new OrderMenuItem
                {
                    MenuItemId = menuItemId,
                    Order = order
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            orderDto.Id = order.Id;
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            if (!_allowedStatuses.Contains(status))
                throw new ArgumentException($"Недопустимий статус: {status}");

            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                throw new ArgumentException($"Замовлення з ID={orderId} не знайдено");

            order.Status = status;
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


