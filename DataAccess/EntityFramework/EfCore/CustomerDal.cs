using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.EfCore
{
    public class CustomerDal : GenericRepository<Customer, Context>, ICustomerDal
    {
        public Customer GetByIdWithSales(int customerId)
        {
            using (var context = new Context())
            {
                return context.Customers
                    .Include(c => c.SaleTransactions)
                    .SingleOrDefault(c => c.CustomerId == customerId);
            }
        }
        public List<Customer> GetCustomersByAddress(string address)
        {
            using (var context = new Context())
            {
                return context.Customers
                    .Where(c => c.Adress.Contains(address))
                    .ToList();
            }
        }

        public List<Customer> GetCustomersByName(string name)
        {
            using (var context = new Context())
            {
                return context.Customers
                    .Where(c => c.Name.Contains(name))
                    .ToList();
            }
        }

        public List<Customer> GetCustomersByPhone(string phone)
        {
            using (var context = new Context())
            {
                return context.Customers
                    .Where(c => c.Phone.Contains(phone))
                    .ToList();
            }
        }

        public List<Customer> GetCustomersBySurname(string surname)
        {
            using (var context = new Context())
            {
                return context.Customers
                    .Where(c => c.SurName.Contains(surname))
                    .ToList();
            }
        }
    }
}
