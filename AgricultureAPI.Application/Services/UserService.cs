using AgricultureAPI.Application.DTOs.User;
using AgricultureAPI.Application.Interfaces;

namespace AgricultureAPI.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<UserDto?> GetByIdAsync(string id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Role = user.Role,
            AvatarUrl = user.AvatarUrl,
            CreatedAt = user.CreatedAt,
            LastLoginAt = user.LastLoginAt
        };
    }

    public async Task<UserDto> UpdateProfileAsync(string id, UpdateProfileRequest request)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found.");

        user.FullName = request.FullName;
        user.AvatarUrl = request.AvatarUrl;

        await _userRepo.UpdateAsync(user);

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Role = user.Role,
            AvatarUrl = user.AvatarUrl,
            CreatedAt = user.CreatedAt,
            LastLoginAt = user.LastLoginAt
        };
    }
}