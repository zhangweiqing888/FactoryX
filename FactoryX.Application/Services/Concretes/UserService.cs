using FactoryX.Application.DTOs;
using FactoryX.Application.DTOs.Requests.AuthenticationRequests;
using FactoryX.Application.DTOs.Requests.UserManagementRequests;
using FactoryX.Application.DTOs.Responses.AuthenticationResponses;
using FactoryX.Application.DTOs.Responses.UserManagementResponses;
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

	public async Task<LoginResponse?> AuthenticateAsync(LoginRequest request)
	{
		var users = await _repositoryManager.UserRepository.GetAllAsync();
		var user = users.FirstOrDefault(u => u.Username == request.Username);
		if (user == null) return null;
		if (!PasswordHasher.VerifyPassword(request.Password, user.PasswordHash)) return null;
		return new LoginResponse
		(
			Id: user.Id,
			Username: user.Username,
			Role: user.Role
		);
	}

	public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
	{
		var users = await _repositoryManager.UserRepository.GetAllAsync();
		if (users.Any(u => u.Username == request.Username))
			throw new InvalidOperationException("Username already exists.");
		var user = new User
		{
			Username = request.Username,
			PasswordHash = PasswordHasher.HashPassword(request.Password),
			Role = request.Role,
			
		};
		_repositoryManager.UserRepository.Create(user);
		await _repositoryManager.SaveAsync();
		return new RegisterResponse
		(
			Id: user.Id,
			Username: user.Username,
			Role: user.Role
		);
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

	public async Task<GetUserProfileResponse?> GetProfileAsync(int userId)
	{
		var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);
		if (user == null) return null;
		return new GetUserProfileResponse
		(
			Id: user.Id,
			UserName: user.Username,
			FullName: user.FullName,
			Email: user.Email
		);
	}

	public async Task UpdateProfileAsync(UserProfileDto dto)
	{
		var user = await _repositoryManager.UserRepository.GetByIdAsync(id: dto.Id, trackChanges: true);
		if (user == null) throw new InvalidOperationException("Kullanıcı bulunamadı.");
		user.Username = dto.UserName;
		user.FullName = dto.FullName;
		user.Email = dto.Email;
		user.UpdatedAt = DateTime.UtcNow;
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
