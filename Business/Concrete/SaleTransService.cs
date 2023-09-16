using Business.Abstract;
using Business.Utilities.Result;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class SaleTransService : ISaleTransService
    {
        private ISaleTransDal _saleTransDal;

        public SaleTransService(ISaleTransDal saleTransDal)
        {
            _saleTransDal = saleTransDal;
        }
        public int GetCount(Expression<Func<SaleTransaction, bool>> filter = null)
        {
            return _saleTransDal.GetCount(filter);
        }
     

        public Iresult Delete(SaleTransaction entity)
        {
            _saleTransDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<SaleTransaction>> GetAll(Expression<Func<SaleTransaction, bool>> filter = null)
        {
            var transactions = _saleTransDal.GetAll(filter);
            return new SuccessDataResult<List<SaleTransaction>>(transactions);
        }

        public IDataResult<List<SaleTransaction>> Getallswrelate()
        {
            var transactions = _saleTransDal.Getallswrelate();
            return new SuccessDataResult<List<SaleTransaction>>(transactions);
        }

        public IDataResult<SaleTransaction> GetById(int id)
        {
            var transaction = _saleTransDal.GetById(id);
            return new SuccessDataResult<SaleTransaction>(transaction);
        }

        public IDataResult<SaleTransaction> GetOne(Expression<Func<SaleTransaction, bool>> filter)
        {
            var transaction = _saleTransDal.GetOne(filter);
            return new SuccessDataResult<SaleTransaction>(transaction);
        }

        public IDataResult<List<SaleTransaction>> GetSalesByCustomer(int customerId)
        {
            var transactions = _saleTransDal.GetSalesByCustomer(customerId);
            return new SuccessDataResult<List<SaleTransaction>>(transactions);
        }

        public IDataResult<List<SaleTransaction>> GetSalesByEmployee(int employeeId)
        {
            var transactions = _saleTransDal.GetSalesByEmployee(employeeId);
            return new SuccessDataResult<List<SaleTransaction>>(transactions);
        }

        public IDataResult<List<SaleTransaction>> GetSalesByProduct(int productId)
        {
            var transactions = _saleTransDal.GetSalesByProduct(productId);
            return new SuccessDataResult<List<SaleTransaction>>(transactions);
        }

        public IDataResult<List<SaleTransaction>> List()
        {
            var transactions = _saleTransDal.List();
            return new SuccessDataResult<List<SaleTransaction>>(transactions);
        }

        public Iresult Update(SaleTransaction entity)
        {
            _saleTransDal.Update(entity);
            return new SuccessResult();
        }

        public Iresult Create(SaleTransaction sale, int productId, int customerId, int personelId)
        {
            _saleTransDal.Create(sale, productId, customerId, personelId);
            return new SuccessResult();
        }

        public IDataResult<SaleTransaction> GetByIdWithAllRelatives(int id)
        {
            var transaction = _saleTransDal.GetByIdWithAllRelatives(id);
            return new SuccessDataResult<SaleTransaction>(transaction);
        }

        public Iresult Update(SaleTransaction sale, int productId, int customerId, int personelId)
        {
            throw new NotImplementedException();
        }
    }
}
