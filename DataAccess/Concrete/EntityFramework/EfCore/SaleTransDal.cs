using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class SaleTransDal : GenericRepository<SaleTransaction>, ISaleTransDal
    {
        public SaleTransDal(Context context) : base(context)
        {
        }
        public List<SaleTransaction> GetSalesByCustomer(int customerId)
        {
            
                return _context.SaleTransactions
                    .Include(s => s.Product)
                    .Include(s => s.Personel)
                    .Where(s => s.CustomerId == customerId)
                    .ToList();
            
        }
        public SaleTransaction GetByIdWithAllRelatives(int id)
        {
            
                return _context.SaleTransactions
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .Include(s => s.Personel)
                .SingleOrDefault(s => s.SalesId == id);
            
        }

        public List<SaleTransaction> Getallswrelate()
        {
           
                return _context.SaleTransactions
                    .Include(s => s.Product)
                    .Include(s => s.Personel)
                    .Include(s => s.Customer)
                    .ToList();
            
        }


        public List<SaleTransaction> GetSalesByEmployee(int personelId)
        {
            
                return _context.SaleTransactions
                    .Include(s => s.Product)
                    .Include(s => s.Customer)
                    .Where(s => s.PersonelId == personelId)
                    .ToList();
            
        }

        public List<SaleTransaction> GetSalesByProduct(int productId)
        {
            
                return _context.SaleTransactions
                    .Where(s => s.ProductId == productId)
                    .ToList();
            
        }

        public List<SaleTransaction> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            
                return _context.SaleTransactions
                    .Where(s => s.Date >= startDate && s.Date <= endDate)
                    .ToList();
            
        }

        public List<SaleTransaction> GetSalesByQuantityRange(int minQuantity, int maxQuantity)
        {
            
                return _context.SaleTransactions
                    .Where(s => s.Quantity >= minQuantity && s.Quantity <= maxQuantity)
                    .ToList();
            
        }

        public List<SaleTransaction> GetSalesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            
                return _context.SaleTransactions
                    .Where(s => s.Price >= minPrice && s.Price <= maxPrice)
                    .ToList();
            
        }
        public void Create(SaleTransaction sale, int productId, int customerId, int personelId)
        {
          
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                var personel = _context.Personels.FirstOrDefault(p => p.PersonelId == personelId);

                if (product != null && customer != null && personel != null)
                {
                    sale.Product = product;
                    sale.Customer = customer;
                    sale.Personel = personel;
                    sale.Date = DateTime.Now;
                    sale.Price = product.Selling_price;
                    _context.SaleTransactions.Add(sale);
                    _context.SaveChanges();
                
            }

        }
        public void Update(SaleTransaction sale, int productId, int customerId, int personelId)
        {
            
                var existingSale = _context.SaleTransactions.FirstOrDefault(s => s.SalesId == sale.SalesId);

                if (existingSale != null)
                {
                    var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                    var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                    var personel = _context.Personels.FirstOrDefault(p => p.PersonelId == personelId);

                    if (product != null && customer != null && personel != null)
                    {
                        existingSale.Product = product;
                        existingSale.Customer = customer;
                        existingSale.Personel = personel;
                        existingSale.Quantity = sale.Quantity;
                        existingSale.Date = sale.Date;
                        existingSale.Price = sale.Product.Selling_price;
                        existingSale.TotalAmount = sale.TotalAmount;

                        _context.SaveChanges();
                    }
                
            }
        }

    }
}
