using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.EfCore
{
    public class CartDal : GenericRepository<Cart,Context>, ICartRepository
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new Context())
            {
                var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }
        public void ClearCart(string cartId)
        {
            using (var context = new Context())
            {
                var cmd = @"delete from CartItems where CartId=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }
        public Cart GetByUserId(string userId)
        {
            using (var context = new Context())
            {
                return context.Carts.Include(i => i.CartItems).ThenInclude(i => i.Product).FirstOrDefault(i => i.UserId == userId);
            }
        }
        public override void Update(Cart entity)
        {
            using (var context = new Context())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
