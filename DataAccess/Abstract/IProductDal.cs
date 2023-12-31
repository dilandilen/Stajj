﻿using Entity;

namespace DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<Product> GetAllWithCategories();
        Product GetProductDetails(int id);

        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
