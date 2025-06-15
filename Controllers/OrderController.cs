using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.API.DTOs;
using RestaurantManagementSystem.API.Services;

namespace RestaurantManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {

            await _orderService.CreateOrder(orderDto);


            return Ok(new { id = orderDto.Id });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _orderService.GetAllOrders());

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            try
            {
                await _orderService.UpdateOrderStatus(id, status);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (!result)
            {
                return NotFound($"Замовлення з ID={id} не знайдено.");
            }

            return NoContent();
        }
    }
}
