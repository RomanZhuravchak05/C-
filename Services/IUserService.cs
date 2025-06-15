using RestaurantManagementSystem.API.DTOs;

namespace RestaurantManagementSystem.API.Services
{
    public interface IUserService
    {
        Task<bool> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
    }
}
