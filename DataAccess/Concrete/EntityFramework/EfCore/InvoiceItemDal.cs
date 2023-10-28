using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class InvoiceItemDal : GenericRepository<InvoiceItem>, IInvoiceItemDal
    {
        public InvoiceItemDal(Context context) : base(context)
        {
        }
        public List<InvoiceItem> GetInvoiceItemsByInvoice(int invoiceId)
        {
            
                return _context.InvoinceItems
                    .Include(x => x.Invoice)
                    .Where(i => i.InvoiceId == invoiceId)
                    .ToList();
            
        }

        public List<InvoiceItem> GetAllWithInvoice()
        {
            

                return _context.InvoinceItems
                .Include(ii => ii.Invoice)
                .ToList();
            
        }

        public List<InvoiceItem> GetInvoiceItemsByTutar(decimal tutar)
        {
            
                return _context.InvoinceItems
                    .Where(ii => ii.Tutar == tutar)
                    .ToList();
            
        }
    }
}
