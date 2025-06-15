using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.API.DTOs;
using RestaurantManagementSystem.API.Services;

namespace RestaurantManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] TableDto tableDto)
        {
            try
            {
                await _tableService.CreateTable(tableDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _tableService.GetAllTables());


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TableDto tableDto)
        {
            var success = await _tableService.UpdateTable(id, tableDto);
            if (!success)
                return NotFound($"Стіл з ID={id} не знайдено.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tableService.DeleteTable(id);
            if (!success)
                return NotFound($"Стіл з ID={id} не знайдено.");

            return NoContent();
        }
    }
}

