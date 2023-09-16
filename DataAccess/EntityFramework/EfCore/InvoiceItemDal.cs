using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.EfCore
{
    public class InvoiceItemDal : GenericRepository<InvoiceItem, Context>, IInvoiceItemDal
    {
        public List<InvoiceItem> GetInvoiceItemsByInvoice(int invoiceId)
        {
            using (var context = new Context())
            {
                return context.InvoinceItems
                    .Include(x => x.Invoice)
                    .Where(i => i.InvoiceId == invoiceId)
                    .ToList();
            }
        }

        public List<InvoiceItem> GetAllWithInvoice()
        {
            using (var context = new Context())
            {

                return context.InvoinceItems
                .Include(ii => ii.Invoice)
                .ToList();
            }
        }

        public List<InvoiceItem> GetInvoiceItemsByTutar(decimal tutar)
        {
            using (var context = new Context())
            {
                return context.InvoinceItems
                    .Where(ii => ii.Tutar == tutar)
                    .ToList();
            }
        }
    }
}
