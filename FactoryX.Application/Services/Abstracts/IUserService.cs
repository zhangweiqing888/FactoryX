using FactoryX.Application.DTOs;
using FactoryX.Application.DTOs.Requests.AuthenticationRequests;
using FactoryX.Application.DTOs.Requests.UserManagementRequests;
using FactoryX.Application.DTOs.Responses.AuthenticationResponses;

namespace FactoryX.Application.Services.Abstracts;

public interface IUserService
{
    Task<LoginResponse?> AuthenticateAsync(LoginRequest request);
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto?> GetByUsernameAsync(string username);
    Task<UserProfileDto?> GetProfileAsync(int userId);
    Task UpdateProfileAsync(UserProfileDto dto);
    Task<bool> ChangePasswordAsync(int userId, ChangePasswordRequest request);
}