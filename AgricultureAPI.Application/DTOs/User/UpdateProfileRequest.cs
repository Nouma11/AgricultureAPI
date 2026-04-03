namespace AgricultureAPI.Application.DTOs.User;

public class UpdateProfileRequest
{
    public string FullName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
}