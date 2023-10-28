using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class CategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public CategoryDal(Context context) : base(context)
        {
        }

        


        public Category GetByIdWithProducts(int id)
        {
            return _context.Categories
                .Where(i => i.CategoryID == id)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Product)
                .FirstOrDefault();
        }

        public List<Category> GetAllCategoryWithProduct()
        {
            return _context.Categories
                .Include(category => category.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .ToList();
        }
    }
}
