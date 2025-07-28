using FactoryX.Application.DTOs;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;
using FactoryX.Application.Helpers;
using FactoryX.Application.Services.Abstracts;

namespace FactoryX.Application.Services.Concretes;

public class UserService : IUserService
{
    private readonly IRepository<User> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto?> AuthenticateAsync(UserLoginDto loginDto)
    {
        var users = await _repository.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Username == loginDto.Username);
        if (user == null) return null;
        if (!PasswordHasher.VerifyPassword(loginDto.Password, user.PasswordHash)) return null;
        return ToDto(user);
    }

    public async Task<UserDto> RegisterAsync(UserRegisterDto registerDto)
    {
        var users = await _repository.GetAllAsync();
        if (users.Any(u => u.Username == registerDto.Username))
            throw new InvalidOperationException("Username already exists.");
        var user = new User
        {
            Username = registerDto.Username,
            PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
            Role = registerDto.Role,
            FullName = registerDto.FullName
        };
        await _repository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(user);
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return user == null ? null : ToDto(user);
    }

    public async Task<UserDto?> GetByUsernameAsync(string username)
    {
        var users = await _repository.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Username == username);
        return user == null ? null : ToDto(user);
    }

    public async Task<UserProfileDto?> GetProfileAsync(int userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user == null) return null;
        return new UserProfileDto
        {
            Id = user.Id,
            UserName = user.Username,
            FullName = user.FullName
        };
    }

    public async Task UpdateProfileAsync(UserProfileDto dto)
    {
        var user = await _repository.GetByIdAsync(dto.Id);
        if (user == null) throw new InvalidOperationException("Kullanıcı bulunamadı.");
        user.Username = dto.UserName;
        user.FullName = dto.FullName;
        _repository.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
        var user = await _repository.GetByIdAsync(dto.UserId);
        if (user == null) return false;
        if (!PasswordHasher.VerifyPassword(dto.CurrentPassword, user.PasswordHash)) return false;
        user.PasswordHash = PasswordHasher.HashPassword(dto.NewPassword);
        _repository.Update(user);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    private static UserDto ToDto(User user) => new()
    {
        Id = user.Id,
        Username = user.Username,
        Role = user.Role
    };
}