using Business.Utilities.Result;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> BekleyenSiparişler();
        List<Order> Kargo();
        List<Order> tamam();
        public List<Order> paket();
        List<Order> GetAllWithOrderLines();
        List<Order> GetAll(Expression<Func<Order, bool>> filter = null);
        IDataResult<Order> GetById(int id);
        Order GetByIdWithOrderItems(int orderıd);

        void Create(Order entity);
        void Update(Order entity);
        List<Order> GetOrders(string userId);
    }
}
