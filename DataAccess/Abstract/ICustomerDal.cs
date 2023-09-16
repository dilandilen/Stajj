using Entity;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IRepository<Customer>
    {
        public Customer GetByIdWithSales(int customerId);
        List<Customer> GetCustomersByName(string name);
        List<Customer> GetCustomersBySurname(string surname);
        List<Customer> GetCustomersByPhone(string phone);
        List<Customer> GetCustomersByAddress(string address);

    }
}
