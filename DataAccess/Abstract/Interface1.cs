using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWishlistRepo:IRepository<Wishlist>
    {

        Wishlist GetByUserId(string userId);
        void DeleteFromWishlist(int cartId, int productId);
    }
}
