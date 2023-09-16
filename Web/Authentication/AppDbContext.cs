using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Web.Authentication
{
	public class AppDbContext: IdentityDbContext<AppUser, AppRole,int>
	{
		public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext) { }

	}
}
