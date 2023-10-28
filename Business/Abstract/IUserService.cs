using DataAccess.Authentication;
using Entity.dto;
using Microsoft.AspNetCore.Identity;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserByIdAsync(int userId);
    Task<UserDetailViewModel> GetUserByEmailAsync(string email);
    Task<IdentityResult> CreateUserAsync(AppUser user, string password);
    Task<AppUser> FindUserByNameAsync(string userName);
    Task<IdentityResult> UpdateUserAsync(AppUser user);
    Task UpdateUserSecurityStampAsync(AppUser user);
    Task<bool> CheckUserPasswordAsync(AppUser user, string password);
    Task<IdentityResult> ChangeUserPasswordAsync(AppUser user, string currentPassword, string newPassword);
    Task ResetUserAccessFailedCountAsync(AppUser user);
    Task UserAccessFailedAsync(AppUser user);
    Task<string> GeneratePasswordResetTokenAsync(AppUser user);
    Task<IdentityResult> ResetUserPasswordAsync(AppUser user, string token, string newPassword);
    Task<int> GetUserAccessFailedCountAsync(AppUser user);
    Task SetUserLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd);
}
