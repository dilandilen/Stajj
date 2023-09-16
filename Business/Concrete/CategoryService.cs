using Business.Abstract;
using Business.Aspect.Autofac.Validation;
using Business.Aspects.Autofac.Caching;
using Business.Utilities.Result;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]

        public Iresult Create(Category entity)
        {
            _categoryDal.Create(entity);
             return new SuccessResult( );
            
        }

        public Iresult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult();

        }

        public Iresult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryDal.DeleteFromCategory(categoryId, productId);
            return new SuccessResult();

        }
        public IDataResult< List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(filter))    ;
        }

        public IDataResult<List<Category>> GetAllCategoryWithProduct()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAllCategoryWithProduct());

        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>( _categoryDal.GetById(id));
        }

        public IDataResult<Category> GetByIdWithProducts(int id)
        {
            return    new SuccessDataResult<Category>(_categoryDal.GetByIdWithProducts(id));
        }

        public int GetCount(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetCount(filter);
        }

        public IDataResult <Category> GetOne(Expression<Func<Category, bool>> filter)
        {
               return new SuccessDataResult<Category>(_categoryDal.GetOne(filter));
        }

        public IDataResult< List<Category>> List()
        {

            return new SuccessDataResult<List<Category>>(_categoryDal.List());
        }
        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]

        public Iresult Update(Category entity)
        {
           
                _categoryDal.Update(entity);
            return new SuccessResult();


        }


    }
}
