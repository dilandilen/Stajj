using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWishlistService
    {
        void AddToWishlist(string userId, int productId);
        Wishlist GetByUserId(string userId);
         void InitializeWish(int userId);
         void DeleteFromWishlist(string userId, int productId)
; 


    }
}
