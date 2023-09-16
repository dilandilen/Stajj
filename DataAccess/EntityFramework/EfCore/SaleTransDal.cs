using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace DataAccess.EntityFramework.EfCore
{
    public class SaleTransDal : GenericRepository<SaleTransaction, Context>, ISaleTransDal
    {
        public List<SaleTransaction> GetSalesByCustomer(int customerId)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Include(s => s.Product)
                    .Include(s => s.Personel)
                    .Where(s => s.CustomerId == customerId)
                    .ToList();
            }
        }
        public SaleTransaction GetByIdWithAllRelatives(int id)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .Include(s => s.Personel)
                .SingleOrDefault(s => s.SalesId == id);
            }
        }

        public List<SaleTransaction> Getallswrelate()
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Include(s => s.Product)
                    .Include(s => s.Personel)
                    .Include(s => s.Customer)
                    .ToList();
            }
        }


        public List<SaleTransaction> GetSalesByEmployee(int personelId)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Include(s => s.Product)
                    .Include(s => s.Customer)
                    .Where(s => s.PersonelId == personelId)
                    .ToList();
            }
        }

        public List<SaleTransaction> GetSalesByProduct(int productId)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Where(s => s.ProductId == productId)
                    .ToList();
            }
        }

        public List<SaleTransaction> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Where(s => s.Date >= startDate && s.Date <= endDate)
                    .ToList();
            }
        }

        public List<SaleTransaction> GetSalesByQuantityRange(int minQuantity, int maxQuantity)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Where(s => s.Quantity >= minQuantity && s.Quantity <= maxQuantity)
                    .ToList();
            }
        }

        public List<SaleTransaction> GetSalesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (var context = new Context())
            {
                return context.SaleTransactions
                    .Where(s => s.Price >= minPrice && s.Price <= maxPrice)
                    .ToList();
            }
        }
        public void Create(SaleTransaction sale, int productId, int customerId, int personelId)
        {
            using (var context = new Context())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                var personel = context.Personels.FirstOrDefault(p => p.PersonelId == personelId);

                if (product != null && customer != null && personel != null)
                {
                    sale.Product = product;
                    sale.Customer = customer;
                    sale.Personel = personel;
                    sale.Date = DateTime.Now;
                    sale.Price = product.Selling_price;
                    context.SaleTransactions.Add(sale);
                    context.SaveChanges();
                }
            }

        }
        public void Update(SaleTransaction sale, int productId, int customerId, int personelId)
        {
            using (var context = new Context())
            {
                var existingSale = context.SaleTransactions.FirstOrDefault(s => s.SalesId == sale.SalesId);

                if (existingSale != null)
                {
                    var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                    var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                    var personel = context.Personels.FirstOrDefault(p => p.PersonelId == personelId);

                    if (product != null && customer != null && personel != null)
                    {
                        existingSale.Product = product;
                        existingSale.Customer = customer;
                        existingSale.Personel = personel;
                        existingSale.Quantity = sale.Quantity; 
                        existingSale.Date = sale.Date;
                        existingSale.Price= sale.Product.Selling_price;
                        existingSale.TotalAmount = sale.TotalAmount;    

                        context.SaveChanges();
                    }
                }
            }
        }

    }
}
