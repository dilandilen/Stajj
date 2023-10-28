using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class CustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public CustomerDal(Context context) : base(context)
        {
        }
        public Customer GetByIdWithSales(int customerId)
        {
            
                return _context.Customers
                    .Include(c => c.SaleTransactions)
                    .SingleOrDefault(c => c.CustomerId == customerId);
            
        }
        public List<Customer> GetCustomersByAddress(string address)
        {
            
                return _context.Customers
                    .Where(c => c.Adress.Contains(address))
                    .ToList();
            
        }

        public List<Customer> GetCustomersByName(string name)
        {
            
                return _context.Customers
                    .Where(c => c.Name.Contains(name))
                    .ToList();
            
        }

        public List<Customer> GetCustomersByPhone(string phone)
        {
            
                return _context.Customers
                    .Where(c => c.Phone.Contains(phone))
                    .ToList();
            
        }

        public List<Customer> GetCustomersBySurname(string surname)
        {
           
                return _context.Customers
                    .Where(c => c.SurName.Contains(surname))
                    .ToList();
            
        }
    }
}
