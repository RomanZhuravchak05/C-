using RestaurantManagementSystem.API.DTOs;

namespace RestaurantManagementSystem.API.Services
{
    public interface ITableService
    {
        Task<IEnumerable<TableDto>> GetAllTables();
        Task CreateTable(TableDto tableDto);
        Task<bool> UpdateTable(int id, TableDto tableDto);
        Task<bool> DeleteTable(int id);
    }
}
