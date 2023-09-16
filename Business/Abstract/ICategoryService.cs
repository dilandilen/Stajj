using Business.Utilities.Result;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService {
        int GetCount(Expression<Func<Category, bool>> filter = null);

        IDataResult<Category> GetById(int id);
        IDataResult< List<Category> >GetAllCategoryWithProduct();
        IDataResult< Category >GetOne(Expression<Func<Category, bool>> filter);
        IDataResult< List<Category>> GetAll(Expression<Func<Category, bool>> filter = null);
    IDataResult<List<Category>> List();

    Iresult Create(Category entity);
        Iresult  Update(Category entity);
        Iresult  Delete(Category entity);
    
        IDataResult<Category> GetByIdWithProducts(int id);
        Iresult DeleteFromCategory(int categoryId, int productId);
    }
}
