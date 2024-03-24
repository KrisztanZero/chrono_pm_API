using Chrono_PM_API.Dtos.AppUser;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chrono_PM_API.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<IEnumerable<AppUserDto>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var userDtoList = UserMapper.MapToDto(users);
        return userDtoList;
    }

    public async Task<AppUserDto> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new ArgumentException($"User not found with id: {id}");
        }
        var userDto = UserMapper.MapToDto(user);
        return userDto;
    }

    public async Task<AppUserDto> UpdateUserAsync(string id, UpdateUserDto updateUserDto)
    {
        var existingUser = await _userManager.FindByIdAsync(id);
        if (existingUser == null)
        {
            throw new ArgumentException($"User not found with id: {id}");
        }
        UserMapper.MapForUpdate(updateUserDto, existingUser);
        var result = await _userManager.UpdateAsync(existingUser);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to update user: {result.Errors}");
        }

        var updatedUser = await _userManager.FindByIdAsync(id);
        if (updatedUser == null)
        {
            throw new Exception($"Updated user not found: {id}");
        }
        return UserMapper.MapToDto(updatedUser);
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new ArgumentException($"User not found with id: {id}");
        }
        
        if (user.UserName == "DeletedUser")
        {
            await _userManager.DeleteAsync(user);
        }
        
        if (user.IsActive)
        {
            user.IsActive = false;
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception($"Failed to update user: {updateResult.Errors}");
            }
        }
        else
        {
            user.UserName = "DeletedUser";
            user.Firstname = "Deleted";
            user.Lastname = "User";
            user.Email = "no email";
            user.PhoneNumber = "no phone";

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception($"Failed to update user: {updateResult.Errors}");
            }

            return true;
        }
        return true;
    }
    
    public async Task<bool> ChangeUserActivationStatusAsync(string id, bool status)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new ArgumentException($"User not found with id: {id}");
        }

        if (user.IsActive == status)
        {
            throw new ArgumentException($"User status already {(user.IsActive ? "Active" : "Inactive")}");
        }
        
        user.IsActive = status;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to update user: {result.Errors}");
        }
        
        return user.IsActive;
    }
}