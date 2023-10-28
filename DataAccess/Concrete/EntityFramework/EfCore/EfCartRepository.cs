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
    public class CartDal : GenericRepository<Cart>, ICartRepository
    {
        public CartDal(Context context) : base(context)
        {
        }
        public void DeleteFromCart(int cartId, int productId)
        {
            var cartItem = _context.CartItems
                .FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public void ClearCart(string cartId)
        {
            var cartItemsToDelete = _context.CartItems
                .Where(ci => ci.CartId.ToString()== cartId);

            if (cartItemsToDelete.Any())
            {
                _context.CartItems.RemoveRange(cartItemsToDelete);
                _context.SaveChanges();
            }
        }

        public Cart GetByUserId(string userId)
        {
            
                return _context.Cartss.Include(i => i.CartItems).ThenInclude(i => i.Product).FirstOrDefault(i => i.UserId == userId);
            
        }
        public override void Update(Cart entity)
        {
            
                _context.Cartss.Update(entity);
                _context.SaveChanges();
            
        }
    }
}
