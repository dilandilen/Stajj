using DataAccess.Authentication;
using Entity.dto;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserDal _userDal;

    public UserService(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task<UserDetailViewModel> GetUserByIdAsync(int userId)
    {
        var user = await _userDal.GetUserByIdAsync(userId);
        return user;
    }

    public async Task<UserDetailViewModel> GetUserByEmailAsync(string email)
    {
        var user = await _userDal.GetUserByEmailAsync(email);
        return user;
    }

    public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
    {
        return await _userDal.CreateAsync(user, password);
    }

    public async Task<AppUser> FindUserByNameAsync(string userName)
    {
        return await _userDal.FindByNameAsync(userName);
    }

    public async Task<IdentityResult> UpdateUserAsync(AppUser user)
    {
        return await _userDal.UpdateAsync(user);
    }

    public async Task UpdateUserSecurityStampAsync(AppUser user)
    {
        await _userDal.UpdateSecurityStampAsync(user);
    }

    public async Task<bool> CheckUserPasswordAsync(AppUser user, string password)
    {
        return await _userDal.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResult> ChangeUserPasswordAsync(AppUser user, string currentPassword, string newPassword)
    {
        return await _userDal.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public async Task ResetUserAccessFailedCountAsync(AppUser user)
    {
        await _userDal.ResetAccessFailedCountAsync(user);
    }

    public async Task UserAccessFailedAsync(AppUser user)
    {
        await _userDal.AccessFailedAsync(user);
    }

    public async Task<string> GeneratePasswordResetTokenAsync(AppUser user)
    {
        return await _userDal.GeneratePasswordResetTokenAsync(user);
    }

    public async Task<IdentityResult> ResetUserPasswordAsync(AppUser user, string token, string newPassword)
    {
        return await _userDal.ResetPasswordAsync(user, token, newPassword);
    }

    public async Task<int> GetUserAccessFailedCountAsync(AppUser user)
    {
        return await _userDal.GetAccessFailedCountAsync(user);
    }

    public async Task SetUserLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd)
    {
        await _userDal.SetLockoutEndDateAsync(user, lockoutEnd);
    }
}
