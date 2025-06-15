using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.API.Data;
using RestaurantManagementSystem.API.DTOs;
using RestaurantManagementSystem.API.Models;

namespace RestaurantManagementSystem.API.Services
{
    public class TableService : ITableService
    {
        private readonly ApplicationDbContext _context;

        public TableService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TableDto>> GetAllTables()
        {
            return await _context.Tables
                .Select(table => new TableDto
                {
                    Id = table.Id,
                    TableNumber = table.TableNumber,
                    Seats = table.Seats
                    
                })
                .ToListAsync();
        }

        public async Task CreateTable(TableDto tableDto)
        {
            var table = new Table
            {
                TableNumber = tableDto.TableNumber,
                Seats = tableDto.Seats
                
            };

            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTable(int id, TableDto tableDto)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            table.TableNumber = tableDto.TableNumber;
            table.Seats = tableDto.Seats;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
