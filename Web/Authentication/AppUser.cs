using Microsoft.AspNetCore.Identity;
using Web.Models;

namespace Web.Authentication
{
	public class AppUser : IdentityUser<int>
	{
		public string FirstName { get; set; }
	     public string LastName { get; set; }

        public static implicit operator UserDetailViewModel(AppUser user)
        {
            return new UserDetailViewModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
        }

    }
}
