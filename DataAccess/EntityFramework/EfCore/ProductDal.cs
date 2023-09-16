using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.EfCore
{
    public class ProductDal : GenericRepository<Product, Context>, IProductDal
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new Context())
            {
                return context.Products
                        .Where(i => i.ProductId == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new Context())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Count();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new Context())
            {
                return context.Products
                            .Where(i => i.ProductId == id)
                            .Include(i => i.ProductCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new Context())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new Context())
            {
                var product = context.Products
                                   .Include(i => i.ProductCategories)
                                   .FirstOrDefault(i => i.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.ProductName = entity.ProductName;
                    product.imgurl = entity.imgurl;
                    product.Stock = entity.Stock;
                    product.Cost_price = entity.Cost_price;
                    product.Selling_price = entity.Selling_price;
                    product.State = entity.State;
                    product.Brandname = entity.Brandname;



                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        CategoryID = catid,
                        ProductId = entity.ProductId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
        public List<Product> GetAllWithCategories()
        {
            using (var context = new Context())
            {
                return context.Products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .ToList();
            }
        }
    }
}
