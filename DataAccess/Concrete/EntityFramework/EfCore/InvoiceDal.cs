using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class InvoinceDal : GenericRepository<Invoice>, IInvoiceDal
    {
        public InvoinceDal(Context context) : base(context)
        {
        }
        public List<Invoice> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        public Invoice GetByIdWithItems(int Iıd)
        {
            
                return _context.Invoinces
                    .Include(c => c.InvoiceItems)
                    .SingleOrDefault(c => c.InvoiceId == Iıd);
            
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
