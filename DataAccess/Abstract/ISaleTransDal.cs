using Entity;

namespace DataAccess.Abstract
{
    public interface ISaleTransDal : IRepository<SaleTransaction>
    {
        public List<SaleTransaction> Getallswrelate();
        public void Create(SaleTransaction sale, int productId, int customerId, int personelId);
        public SaleTransaction GetByIdWithAllRelatives(int id);
        public void Update(SaleTransaction sale, int productId, int customerId, int personelId);

        List<SaleTransaction> GetSalesByEmployee(int employeeId);
        List<SaleTransaction> GetSalesByCustomer(int customerId);
        List<SaleTransaction> GetSalesByProduct(int productId);
    }
}
