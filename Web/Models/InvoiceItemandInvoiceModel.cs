using Entity;

namespace Web.Models
{
    public class InvoiceItemandInvoiceModel
    {
        public Invoice Invoice { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
