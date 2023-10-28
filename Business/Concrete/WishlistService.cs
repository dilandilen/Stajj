using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WishlistService:IWishlistService
    {
        private IWishlistRepo _wishlistRepo;
        public WishlistService(IWishlistRepo wishlistRepo)
        {
            _wishlistRepo = wishlistRepo;
        }
        public void AddToWishlist(string userId, int productId)
        {
            var wish = GetByUserId(userId);
            if (wish != null)
            {
                var index = wish.Items.FindIndex(i => i.ProductId == productId);
                if (index < 0)
                {
                    wish.Items.Add(new WishlistItem()
                    {
                        ProductId = productId,
                        WishlistId = wish.WishlistId
                    });
                }
                
                _wishlistRepo.Update(wish);
            }
        }
        public Wishlist GetByUserId(string userId)
        {
            return _wishlistRepo.GetByUserId(userId);
        }
        public void InitializeWish(int userId)
        {
            _wishlistRepo.Create(new Wishlist()
            {
                UserId = userId.ToString(),
            });
        }
        public void DeleteFromWishlist(string userId, int productId)
        {
            var wish = GetByUserId(userId);
            if (wish != null)
            {
                _wishlistRepo.DeleteFromWishlist(wish.WishlistId, productId);
            }
        }

      
    }
}
