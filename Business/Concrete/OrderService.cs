using Business.Abstract;
using Business.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderService : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderService(IOrderDal orderDal) { 
     
            _orderDal = orderDal;
        }
        public List<Order> GetAllWithOrderLines()
        {
            return _orderDal.GetAllWithOrderLines();
        }
        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
       public List<Order> BekleyenSiparişler()
        {
            return _orderDal.BekleyenSiparişler();
        }
        public List<Order> Kargo()
        {
            return _orderDal.Kargo();
        }
        public List<Order> tamam()
        {
            return _orderDal.tamam();
        }
         public List<Order> paket()
        {
            return _orderDal.paket();
        }
        public Order GetByIdWithOrderItems(int orderıd)
        {
           return _orderDal.GetByIdWithOrderItems(orderıd);
        }

        public IDataResult<Order> GetById(int id)
        {
            var product = _orderDal.GetById(id);
            return new SuccessDataResult<Order>(product);
        }
        public void Create(Order entity)
        {
            _orderDal.Create(entity);
        }

        public List<Order> GetOrders(string userId)
        {
            return _orderDal.GetOrders(userId);
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.GetAll(filter);        }
    }
}
