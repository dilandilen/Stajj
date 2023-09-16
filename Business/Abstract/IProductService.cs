using Business.Utilities.Result;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        int GetCount(Expression<Func<Product, bool>> filter = null);
        int GetTotalStock();
        IDataResult< List<Product>> GetProductsByLowStock(int minimumStock);
        int GetBrandCount();


        Iresult TransactionalOperation(Product product);
        IDataResult< Product> GetById(int id);
        IDataResult< List<Product>> GetAllWithCategories();
        IDataResult< Product> GetOne(Expression<Func<Product, bool>> filter);
        IDataResult< List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        IDataResult<List<Product>> List();

        Iresult Create(Product entity);
        Iresult Delete(Product entity);

        IDataResult<List<Product>> GetProductsByCategory(string category, int page, int pageSize);

        IDataResult<Product> GetProductDetails(int id);

        int GetCountByCategory(string category);
        IDataResult<Product> GetByIdWithCategories(int id);
        Iresult Update(Product entity, int[] categoryIds);
    }
}
