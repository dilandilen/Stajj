using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        List<Order> BekleyenSiparişler();
        List<Order> Kargo();
        List<Order> tamam();
        public List<Order> paket();


         List<Order> GetAllWithOrderLines();

        Order GetByIdWithOrderItems(int orderıd);

        List<Order> GetOrders(string userId);
    }
}
