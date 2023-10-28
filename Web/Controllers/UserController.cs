using Business.Abstract;
using Business.Concrete;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web;
using Castle.Core.Smtp;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Web.Viewcomponent;
using DataAccess.Authentication;
using Entity.dto;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Controllers
{


    public class UserController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		private readonly ICustomerService _customerService;
		readonly SignInManager<AppUser> _signInManager;
        private readonly IPersonelService _personelService;
        private readonly ICartService _cartService;

        public UserController(UserManager<AppUser> userManager,ICustomerService customerService, SignInManager<AppUser> signInManager, IPersonelService personelService
, ICartService cartService)
        {
            _personelService = personelService;
            _userManager = userManager;
            _customerService = customerService;
            _signInManager = signInManager;
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult users()
        {

            
                return View(_userManager.Users);
            

        }
        [HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(RegisterDto registerDto)
		{
			if (!ModelState.IsValid)
			{
                return View();
            }
            else {
                AppUser appUser = new AppUser
                {
                    UserName = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,


                };
                IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (result.Succeeded)
                {

                    var entity = new Customer
                    {
                        Name = registerDto.FirstName,
                        SurName = registerDto.LastName,
                        Email = registerDto.Email,
                        Phone = registerDto.PhoneNumber,
                        IsDelete = false,
                        Adress = "AA",
                    };
                    _cartService.InitializeCart(appUser.Id);

                    _customerService.Create(entity);
                    return RedirectToAction("Index", "CustomerPanel");
                }

                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }

            return View();
        }
        [HttpGet]

        public async Task<IActionResult> EditProfile()
        {
            UserDetailViewModel userDetail = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(userDetail);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = model.PhoneNumber;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                    return View(model);
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, true);
            }

            return RedirectToAction("Index", "CustomerPanel");
        }
        public IActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(EditPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (await _userManager.CheckPasswordAsync(user, model.OldPassword))
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (!result.Succeeded)
                    {
                        result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                        return View(model);
                    }
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, true);
                }
            }
            return RedirectToAction("Index", "CustomerPanel");
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            TempData["returnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Persistent, false);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user); 

                        if (string.IsNullOrEmpty(TempData["returnUrl"] != null ? TempData["returnUrl"].ToString() : ""))
                            return RedirectToAction("Index", "CustomerPanel");
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user); 
                        int failcount = await _userManager.GetAccessFailedCountAsync(user); 
                        if (failcount == 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1)));  
                            ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kitlenmiştir.");
                        }
                        else
                        {
                            if (result.IsLockedOut)
                                ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kitlenmiştir.");
                            else
                                ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                    ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult PersonelLogin(string ReturnUrl)
        {
            TempData["returnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PersonelLogin(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Persistent, false);
                    var bilgiler = _personelService.GetAll().Data.FirstOrDefault(x => x.Email == model.Email);
                    if (result.Succeeded && bilgiler!=null)
                    {

                        if (string.IsNullOrEmpty(TempData["returnUrl"] != null ? TempData["returnUrl"].ToString() : ""))
                            return RedirectToAction("Index", "Category");
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                   
                    
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                    ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","CustomerPanel");
        }
        [HttpGet]
        public IActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetPassword model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);

             
                mail.From = new MailAddress("dilandilen12@outlook.com", "Şifre Güncelleme", Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:7071{Url.Action("UpdatePassword", "User", new { userId = user.Id, token = HttpUtility.UrlEncode(resetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp-mail.outlook.com",
                    Port = 587,
                    Timeout = 60000,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("dilandilen12@outlook.com", "Ab121144.")
                };
                smtpClient.Send(mail);
                smtpClient.Dispose();
                ViewBag.State = true;
            }
            else
                ViewBag.State = false;

            return View();
          
        }
        public async Task<IActionResult> Profile()
        {
            UserDetailViewModel userDetail = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(userDetail);
        }
        [HttpGet("[action]/{userId}/{token}")]
        public IActionResult UpdatePassword(string userId, string token)
        {
            return View();
        }
        [HttpPost("[action]/{userId}/{token}")]
        public async Task<IActionResult> UpdatePassword(UpdatePassword model, string userId, string token)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(token), model.Password);
            if (result.Succeeded)
            {
                ViewBag.State = true;
                await _userManager.UpdateSecurityStampAsync(user);
            }
            else
                ViewBag.State = false;
            return View();
        }
    }
}

