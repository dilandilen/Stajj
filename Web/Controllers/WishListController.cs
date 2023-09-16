using DataAccess.Concrete;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

public class WishlistController : Controller
{
    private readonly Context _context; // DbContext'e uygun bağlamı ekleyin

    public WishlistController(Context context)
    {
        _context = context;
    }

    // Kullanıcının Wishlist'ini görüntüleme
    public IActionResult Index(string userId)
    {
        var wishlist = _context.WishlistItems
            .Where(w => w.UserId == userId)
            .ToList();

        return View(wishlist);
    }

    // Ürünü Wishlist'e ekleme
    [HttpPost]
    public IActionResult AddToWishlist(string userId, int productId)
    {
        var existingItem = _context.WishlistItems
            .FirstOrDefault(w => w.UserId == userId && w.ProductId == productId);

        if (existingItem != null)
        {
            // Ürün zaten Wishlist'te, burada isteğe bağlı olarak bir mesaj gönderebilirsiniz.
        }
        else
        {
            var wishlistItem = new WishlistItem
            {
                UserId = userId,
                ProductId = productId,
                AddedDate = DateTime.Now
            };

            _context.WishlistItems.Add(wishlistItem);
            _context.SaveChanges();
        }

        return RedirectToAction("Index", new { userId });
    }

    // Ürünü Wishlist'ten kaldırma
    [HttpPost]
    public IActionResult RemoveFromWishlist(string userId, int wishlistItemId)
    {
        var itemToRemove = _context.WishlistItems
            .FirstOrDefault(w => w.UserId == userId && w.Id == wishlistItemId);

        if (itemToRemove != null)
        {
            _context.WishlistItems.Remove(itemToRemove);
            _context.SaveChanges();
        }

        return RedirectToAction("Index", new { userId });
    }
}
