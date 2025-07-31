using FactoryX.Application.DTOs;
using FactoryX.Application.DTOs.Requests.UserManagementRequests;
using FactoryX.Application.Helpers;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Domain.Entities;
using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Application.Services.Concretes;

public class UserService : IUserService
{
	private readonly IRepositoryManager _repositoryManager;

	public UserService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<UserDto?> AuthenticateAsync(UserLoginDto loginDto)
	{
		var users = await _repositoryManager.UserRepository.GetAllAsync();
		var user = users.FirstOrDefault(u => u.Username == loginDto.Username);
		if (user == null) return null;
		if (!PasswordHasher.VerifyPassword(loginDto.Password, user.PasswordHash)) return null;
		return ToDto(user);
	}

	public async Task<UserDto> RegisterAsync(UserRegisterDto registerDto)
	{
		var users = await _repositoryManager.UserRepository.GetAllAsync();
		if (users.Any(u => u.Username == registerDto.Username))
			throw new InvalidOperationException("Username already exists.");
		var user = new User
		{
			Username = registerDto.Username,
			PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
			Role = registerDto.Role,
			FullName = registerDto.FullName
		};
		_repositoryManager.UserRepository.Create(user);
		await _repositoryManager.SaveAsync();
		return ToDto(user);
	}

	public async Task<UserDto?> GetByIdAsync(int id)
	{
		var user = await _repositoryManager.UserRepository.GetByIdAsync(id);
		return user == null ? null : ToDto(user);
	}

	public async Task<UserDto?> GetByUsernameAsync(string username)
	{
		var users = await _repositoryManager.UserRepository.GetAllAsync();
		var user = users.FirstOrDefault(u => u.Username == username);
		return user == null ? null : ToDto(user);
	}

	public async Task<UserProfileDto?> GetProfileAsync(int userId)
	{
		var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);
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
		var user = await _repositoryManager.UserRepository.GetByIdAsync(id: dto.Id, trackChanges: true);
		if (user == null) throw new InvalidOperationException("Kullanıcı bulunamadı.");
		user.Username = dto.UserName;
		user.FullName = dto.FullName;
		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.SaveAsync();
	}

	public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordRequest request)
	{
		var user = await _repositoryManager.UserRepository.GetByIdAsync(id: userId, trackChanges: true);
		if (user == null) return false;
		if (!PasswordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash)) return false;

		user.PasswordHash = PasswordHasher.HashPassword(request.NewPassword);
		user.UpdatedAt = DateTime.UtcNow;

		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.SaveAsync();

		return true;
	}

	private static UserDto ToDto(User user) => new()
	{
		Id = user.Id,
		Username = user.Username,
		Role = user.Role
	};
}