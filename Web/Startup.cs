using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Http;
using System;

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Extensions;
using Business.Utilities.IoC;
using Business.DependencyResolvers;
using Web.CustomValidations;
using DataAccess.Authentication;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
		{
            string connectionString = Configuration.GetConnectionString("ConnectionStrings");

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConnectionStrings"]));




            services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.Password.RequiredLength = 5; 
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false; 
				options.Password.RequireDigit = false;
				options.User.AllowedUserNameCharacters = null; 
				options.User.RequireUniqueEmail = true; 
				options.SignIn.RequireConfirmedAccount = false; 
                 options .User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";
			}).AddPasswordValidator<CustomPasswordValidation>()
              .AddUserValidator<CustomUserValidation>()
              .AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<Context>()
              .AddDefaultTokenProviders(); ;

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/User/Login");
                _.LogoutPath = new PathString("/User/Logout");
                _.Cookie = new CookieBuilder
                {
                    Name = "DilanMarketCookie", //Oluşturulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //Kötü niyetli insanların client-side tarafından Cookie'ye erişmesini engelliyoruz.
                    MaxAge = TimeSpan.FromMinutes(120)       ,        
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.None //HTTPS üzerinden erişilebilir yapıyoruz.
                };
                _.SlidingExpiration = true; //Expiration süresinin yarısı kadar süre zarfında istekte bulunulursa eğer geri kalan yarısını tekrar sıfırlayarak ilk ayarlanan süreyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromDays(10); //CookieBuilder nesnesinde tanımlanan Expiration değerinin varsayılan değerlerle ezilme ihtimaline karşın tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/authority/page");
            });
            services.AddDistributedMemoryCache(); // Example: Use an in-memory cache for session data
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust the session timeout as needed
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<Context>();
            services.AddControllersWithViews();
            services.AddDependencyResolvers(new IBusinessModule[]{
                new BusinessModule()
            });

           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();//sayfaları bölme

            app.UseAuthentication(); // Kimlik doğrulama middleware'ini kullanın
            app.UseAuthorization();
            app.UseSession(); // Add this line to enable session middleware

            app.UseEndpoints(endpoints =>//routing endpoints anla
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CustomerPanel}/{action=Index}/{id?}");
            });
        }
    }
}
