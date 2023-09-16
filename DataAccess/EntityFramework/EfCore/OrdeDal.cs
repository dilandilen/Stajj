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
    public class OrderDal : GenericRepository<Order,Context>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new Context())
            {
                var orders = context.Orders
                                .Include(i => i.OrderItems)
                                .ThenInclude(i => i.Product)
                                .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);
                }

                return orders.ToList();
            }
        }
        public Order GetByIdWithOrderItems(int orderId)
        {
            using (var context = new Context())
            {
                var order = context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(o => o.Id == orderId);

                return order;
            }
        }
        public List<Order> GetAllWithOrderLines()
        {
            using (var context = new Context())
            {
                var orders = context.Orders
                    .Include(o => o.OrderItems) // Sipariş satırlarını dahil et
                    .ThenInclude(oi => oi.Product) // Ürünleri dahil et
                    .ToList();

                return orders;
            }
        }
    }
}
