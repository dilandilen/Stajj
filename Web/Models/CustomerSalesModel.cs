using System.Collections.Generic;
using Entity; 

namespace Web.Models
{
    public class CustomerSalesModel
    {
        public Customer Customer { get; set; }
        public List<SaleTransaction> SaleTransactions { get; set; } 
    }
}
