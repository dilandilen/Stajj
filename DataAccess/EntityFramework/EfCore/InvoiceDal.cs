using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.EfCore
{
    public class InvoinceDal : GenericRepository<Invoice, Context>, IInvoiceDal
    {
        public List<Invoice> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        public Invoice GetByIdWithItems(int Iıd)
        {
            using (var context = new Context())
            {
                return context.Invoinces
                    .Include(c => c.InvoiceItems)
                    .SingleOrDefault(c => c.InvoiceId == Iıd);
            }
        }
        public List<Invoice> GetInvoicesByDeliverd(string deliverd)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetInvoicesByReceived(string received)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetInvoicesByTaxAdministration(string taxAdministration)
        {
            throw new NotImplementedException();
        }
    }
}
