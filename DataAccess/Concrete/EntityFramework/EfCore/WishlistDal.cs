using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class WishlistDal : GenericRepository<Wishlist>, IWishlistRepo
    {

        public WishlistDal(Context context) : base(context)
        {
        }

        public void DeleteFromWishlist(int wishlistId, int productId)
        {
            var itemToDelete = _context.Items
                .FirstOrDefault(item => item.WishlistId == wishlistId && item.ProductId == productId);

            if (itemToDelete != null)
            {
                _context.Items.Remove(itemToDelete);
                _context.SaveChanges();
            }
        }

        public Wishlist GetByUserId(string userId)
        {
            return _context.Wishlists.Include(i => i.Items).ThenInclude(i => i.Product).FirstOrDefault(i => i.UserId == userId);
        }

        public override void Update(Wishlist entity)
        {
            _context.Wishlists.Update(entity);
            _context.SaveChanges();
        }
    }
}
