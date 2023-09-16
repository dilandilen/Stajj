using Entity;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByIdWithProducts(int id);
        void DeleteFromCategory(int categoryId, int productId);
        public List<Category> GetAllCategoryWithProduct();
    }
}
