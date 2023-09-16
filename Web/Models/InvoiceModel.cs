using Entity;

namespace Web.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }

   
        public string InvoiceSerialNo { get; set; }

    
        public string InvoiceOrderNo { get; set; }
        public DateTime Date { get; set; }

       
        public string TaxAdministration { get; set; } //VergiDairesi
     
        public string Clock { get; set; }

        public decimal Sum { get; set; }


        public string Received { get; set; }

    
        public string Delivered { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
