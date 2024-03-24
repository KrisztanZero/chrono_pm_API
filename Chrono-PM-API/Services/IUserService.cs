using Chrono_PM_API.Dtos.AppUser;

namespace Chrono_PM_API.Services;

public interface IUserService
{
    Task<IEnumerable<AppUserDto>> GetUsersAsync();
    Task<AppUserDto> GetUserByIdAsync(string id);
    Task<AppUserDto> UpdateUserAsync(string id, UpdateUserDto updateUser);
    Task<bool> DeleteUserAsync(string id);
    Task<bool> ChangeUserActivationStatusAsync(string id, bool status);
}