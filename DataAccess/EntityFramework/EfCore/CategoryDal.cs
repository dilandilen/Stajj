using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.EfCore
{
    public class CategoryDal : GenericRepository<Category, Context>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context = new Context())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context = new Context())
            {
                return context.Categories
                        .Where(i => i.CategoryID == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault();
            }
        }
        public List<Category> GetAllCategoryWithProduct()
        {
            using (var context = new Context())
            {
                return context.Categories
                    .Include(category => category.ProductCategories)
                    .ThenInclude(pc => pc.Product)
                    .ToList();
            }
        }
    }
}
