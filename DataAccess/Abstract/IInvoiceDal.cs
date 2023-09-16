using Entity;

namespace DataAccess.Abstract
{
    public interface IInvoiceDal : IRepository<Invoice>
    {

        public Invoice GetByIdWithItems(int Iıd)
;
        List<Invoice> GetInvoicesByDateRange(DateTime startDate, DateTime endDate);
        List<Invoice> GetInvoicesByTaxAdministration(string taxAdministration);
        List<Invoice> GetInvoicesByReceived(string received);
        List<Invoice> GetInvoicesByDeliverd(string deliverd);
    }
}
