using DataAccess.Abstract;
using Entity;
using Entity.dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class OrderDal : GenericRepository<Order>, IOrderDal
    {
        public OrderDal(Context context) : base(context)
        {
        }
        public List<Order> GetOrders(string userId)
        {
            
                var orders = _context.Orders
                                .Include(i => i.OrderItems)
                                .ThenInclude(i => i.Product)
                                .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);
                }

                return orders.ToList();
            
        }
        public List<Order> BekleyenSiparişler()
        {
            var orders = GetAll().Where(i => i.OrderState == EnumOrderState.Bekleniyor).Select(i => new Order()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,

            }).OrderByDescending(i => i.OrderDate).ToList();
            return orders;
        }
        public List<Order> Kargo()
        {
            var orders = GetAll().Where(i => i.OrderState == EnumOrderState.Kargolandı).Select(i => new Order()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,

            }).OrderByDescending(i => i.OrderDate).ToList();
            return orders;
        }
        public List<Order> tamam()
        {
            var orders = GetAll().Where(i => i.OrderState == EnumOrderState.Tamamlandı).Select(i => new Order()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,

            }).OrderByDescending(i => i.OrderDate).ToList();
            return orders;
        }
        public List<Order> paket()
        {
            var orders = GetAll().Where(i => i.OrderState == EnumOrderState.Paketlendi).Select(i => new Order()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,

            }).OrderByDescending(i => i.OrderDate).ToList();
            return orders;
        }
        public Order GetByIdWithOrderItems(int orderId)
        {
            
                var order = _context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(o => o.Id == orderId);

                return order;
            
        }
        public List<Order> GetAllWithOrderLines()
        {
            
                var orders = _context.Orders
                    .Include(o => o.OrderItems) // Sipariş satırlarını dahil et
                    .ThenInclude(oi => oi.Product) // Ürünleri dahil et
                    .ToList();

                return orders;
            
        }
    }
}
