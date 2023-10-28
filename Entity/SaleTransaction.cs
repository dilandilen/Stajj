
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SaleTransaction
    {
        [Key]
        public int SalesId{ get; set; }
       
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Price
        { get; set; }
        
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PersonelId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
