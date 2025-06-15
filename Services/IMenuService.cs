using RestaurantManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantManagementSystem.Services;

namespace RestaurantManagementSystem.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItemDto>> GetAllItems();
        Task<MenuItemDto> GetMenuItemById(int id); 
        Task<MenuItemDto> CreateMenuItem(MenuItemDto menuItemDto);
        Task<bool> UpdateMenuItem(int id, MenuItemDto menuItemDto);
        Task<bool> DeleteMenuItem(int id);
    }
}

