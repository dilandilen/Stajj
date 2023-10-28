using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class ProductDal : GenericRepository<Product>, IProductDal
    {
        public ProductDal(Context context) : base(context)
        {
        }
        public Product GetByIdWithCategories(int id)
        {
            
                return _context.Products
                        .Where(i => i.ProductId == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .FirstOrDefault();
            
        }

        public int GetCountByCategory(string category)
        {
            
                var products = _context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Count();
            
        }

        public Product GetProductDetails(int id)
        {
            
                return _context.Products
                            .Where(i => i.ProductId == id)
                            .Include(i => i.ProductCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();
            
        }


        public void Update(Product entity, int[] categoryIds)
        {
            
                var product = _context.Products
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

                    _context.SaveChanges();
                
            }
        }
        public List<Product> GetAllWithCategories()
        {
            
                return _context.Products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .ToList();
            
        }
    }
}
