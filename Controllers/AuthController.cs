using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.API.DTOs;
using RestaurantManagementSystem.API.Services;

namespace RestaurantManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password))
            {
                return BadRequest(new { message = "Ім'я користувача та пароль обов'язкові" });
            }

            var result = await _userService.Register(userDto);
            if (!result)
                return BadRequest(new { message = "Користувач уже існує" });

            return Ok(new { message = "Користувач успішно зареєстрований" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password))
            {
                return BadRequest("Ім'я користувача та пароль обов'язкові");
            }

            var token = await _userService.Login(userDto);
            if (token == null)
                return Unauthorized(new { message = "Неправильне ім'я користувача або пароль" });

            return Ok(new { Token = token });
        }
    }
}



