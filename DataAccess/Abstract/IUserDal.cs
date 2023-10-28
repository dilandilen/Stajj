using DataAccess.Authentication;
using Microsoft.AspNetCore.Identity;

public interface IUserDal
{
    Task<AppUser> GetUserByIdAsync(int userId);
    Task<AppUser> GetUserByEmailAsync(string email);
    Task<IdentityResult> CreateAsync(AppUser user, string password);
    Task<AppUser> FindByNameAsync(string name);
    Task<IdentityResult> UpdateAsync(AppUser user);
    Task UpdateSecurityStampAsync(AppUser user);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<IdentityResult> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword);
    Task ResetAccessFailedCountAsync(AppUser user);
    Task AccessFailedAsync(AppUser user);
    Task<string> GeneratePasswordResetTokenAsync(AppUser user);
    Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword);
    Task<int> GetAccessFailedCountAsync(AppUser user);
    Task SetLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd);
}
