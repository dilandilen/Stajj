using Entity;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByIdWithProducts(int id);
        public List<Category> GetAllCategoryWithProduct();
    }
}
