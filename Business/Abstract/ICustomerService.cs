using Business.Utilities.Result;
using Entity;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        int GetCount(Expression<Func<Customer, bool>> filter = null);

        IDataResult< Customer> GetById(int id);
        IDataResult<Customer> GetByIdWithSales(int customerId);
        IDataResult<Customer> GetOne(Expression<Func<Customer, bool>> filter);
        IDataResult< List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null);
        IDataResult<List<Customer>> List();

        Iresult Create(Customer entity);
        Iresult Update(Customer entity);
        Iresult Delete(Customer entity);

        IDataResult<List<Customer>> GetCustomersByName(string name);
        IDataResult<List<Customer>> GetCustomersBySurname(string surname);
        IDataResult<List<Customer>> GetCustomersByPhone(string phone);
        IDataResult<List<Customer>> GetCustomersByAddress(string address);
   
    }
}
