using Entity;

namespace DataAccess.Abstract
{
    public interface IInvoiceItemDal : IRepository<InvoiceItem>
    {

        public List<InvoiceItem> GetAllWithInvoice();

        List<InvoiceItem> GetInvoiceItemsByTutar(decimal tutar);
        List<InvoiceItem> GetInvoiceItemsByInvoice(int invoiceId);

    }
}
