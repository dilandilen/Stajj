using Entity;

namespace Web.Models
{
    public class PersonelSalesModel
    {
        public Personel Personel { get; set; }
        public List<SaleTransaction> SaleTransactions { get; set; }
    }
}
