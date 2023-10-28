using DataAccess.Authentication;
using Entity.dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class UserDal : GenericRepository<AppUser>, IUserDal
    {
        private readonly UserManager<AppUser> _userManager;

       
        public UserDal(Context context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;

        }
        public IQueryable<AppUser> GetAll()
        {
            return _userManager.Users;
        }
        public async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<AppUser> FindByNameAsync(string Name)
        {
           return await _userManager.FindByNameAsync(Name);
        }
        public async Task<IdentityResult> UpdateAsync(AppUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task UpdateSecurityStampAsync(AppUser user)
        {
            await _userManager.UpdateSecurityStampAsync(user);
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task ResetAccessFailedCountAsync(AppUser user)
        {
            await _userManager.ResetAccessFailedCountAsync(user);
        }

        public async Task AccessFailedAsync(AppUser user)
        {
            await _userManager.AccessFailedAsync(user);
        }
        public async Task<string> GeneratePasswordResetTokenAsync(AppUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }


        public async Task<int> GetAccessFailedCountAsync(AppUser user)
        {
            return await _userManager.GetAccessFailedCountAsync(user);
        }

        public async Task SetLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd)
        {
            await _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
        }

        public Task<AppUser> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
