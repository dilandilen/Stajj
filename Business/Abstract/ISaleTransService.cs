using Business.Utilities.Result;
using Entity;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ISaleTransService 
    {
        int GetCount(Expression<Func<SaleTransaction, bool>> filter = null);
         Iresult Create(SaleTransaction sale, int productId, int customerId, int personelId)
;  IDataResult< SaleTransaction> GetByIdWithAllRelatives(int id);
        Iresult Update(SaleTransaction sale, int productId, int customerId, int personelId);

        IDataResult< SaleTransaction >GetById(int id);
        IDataResult< List<SaleTransaction> >Getallswrelate();

        IDataResult< SaleTransaction >GetOne(Expression<Func<SaleTransaction, bool>> filter);
        IDataResult< List<SaleTransaction> >GetAll(Expression<Func<SaleTransaction, bool>> filter = null);
        IDataResult< List<SaleTransaction>> List();
            
        Iresult Update(SaleTransaction entity);
        Iresult Delete(SaleTransaction entity);
        IDataResult<List<SaleTransaction>> GetSalesByEmployee(int employeeId);
        IDataResult<List<SaleTransaction>> GetSalesByCustomer(int customerId);
        IDataResult<List<SaleTransaction>> GetSalesByProduct(int productId);
    }
}
