using Business.Abstract;
using Business.Aspect.Autofac.Validation;
using Business.Utilities.Result;
using Business.ValidationRules.FluentValidation;
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
    public class CustomerService : ICustomerService
    {
        private ICustomerDal _customerDal;
       
        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [ValidationAspect(typeof(CustomerValidator ), Priority = 1)]

        public Iresult Create(Customer entity)
        {
            
                _customerDal.Create(entity);
            return new SuccessResult();


        }

        public Iresult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult();

        }


        public IDataResult< List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return  new SuccessDataResult<List<Customer>>(  _customerDal.GetAll(filter));
        }

        public IDataResult< Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>( _customerDal.GetById(id));
        }

        public IDataResult< Customer >GetByIdWithSales(int customerId)
        {
            return new SuccessDataResult<Customer>( _customerDal.GetByIdWithSales(customerId));
        }

        public IDataResult< List<Customer>> GetCustomersByAddress(string address)
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.GetCustomersByAddress(address));
        }

        public IDataResult< List<Customer>> GetCustomersByName(string name)
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.GetCustomersByName(name));
        }

        public IDataResult<List<Customer>> GetCustomersByPhone(string phone)
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.GetCustomersByPhone(phone));
        }

        public IDataResult< List<Customer>> GetCustomersBySurname(string surname)
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.GetCustomersBySurname(surname));
        }

        public IDataResult<Customer> GetOne(Expression<Func<Customer, bool>> filter)
        {
            return new SuccessDataResult<Customer>( _customerDal.GetOne(filter));
        }

        public IDataResult <List<Customer>> List()
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.List());
        }
        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]

        public Iresult Update(Customer entity)
        {
               _customerDal.Update(entity);
            return new SuccessResult();

        }

       

        public int GetCount(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetCount(filter);
        }
    }
}
