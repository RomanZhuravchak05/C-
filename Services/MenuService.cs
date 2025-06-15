using RestaurantManagementSystem.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagementSystem.API.Data;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.API.Models;

namespace RestaurantManagementSystem.Services
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllItems()
        {
            return _context.MenuItems.Select(item => new MenuItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            });
        }

        public async Task<MenuItemDto> GetMenuItemById(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null)
                return null;

            return new MenuItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };
        }

        public async Task<MenuItemDto> CreateMenuItem(MenuItemDto menuItemDto)
        {
            var item = new MenuItem
            {
                Name = menuItemDto.Name,
                Description = menuItemDto.Description,
                Price = menuItemDto.Price
            };

            _context.MenuItems.Add(item);
            await _context.SaveChangesAsync();

            menuItemDto.Id = item.Id;
            return menuItemDto;
        }

        public async Task<bool> UpdateMenuItem(int id, MenuItemDto menuItemDto)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null)
                return false;

            item.Name = menuItemDto.Name;
            item.Description = menuItemDto.Description;
            item.Price = menuItemDto.Price;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMenuItem(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null)
                return false;

            _context.MenuItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
