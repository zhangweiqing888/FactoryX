using FactoryX.Application.DTOs;

namespace FactoryX.Application.Services.Abstracts;

public interface IUserService
{
    Task<UserDto?> AuthenticateAsync(UserLoginDto loginDto);
    Task<UserDto> RegisterAsync(UserRegisterDto registerDto);
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto?> GetByUsernameAsync(string username);
    Task<UserProfileDto?> GetProfileAsync(int userId);
    Task UpdateProfileAsync(UserProfileDto dto);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
}