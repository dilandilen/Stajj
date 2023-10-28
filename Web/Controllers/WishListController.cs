using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Authentication;

namespace Web.Controllers
{
    public class WishlistController: Controller
    {
        private UserManager<AppUser> _userManager;
        private IWishlistService _wishlistService;
       public WishlistController(UserManager<AppUser> userManager, IWishlistService wishlistService)
        {
            _userManager = userManager;
            _wishlistService = wishlistService;
        }
        public IActionResult Index()
        {
            var wish = _wishlistService.GetByUserId(_userManager.GetUserId(User));
            return View(wish);
        }
        [HttpPost]
        public IActionResult AddToWishlist(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _wishlistService.AddToWishlist(userId, productId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _wishlistService.DeleteFromWishlist(userId, productId);
            return RedirectToAction("Index");
        }
    }
}
