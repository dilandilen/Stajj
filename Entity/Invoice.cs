using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{    
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string InvoiceOrderNo { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; } //VergiDairesi
        [Column(TypeName = "VarChar")]
        [StringLength(5)]
        public string Clock { get; set; }

        public decimal Sum { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Received { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Delivered { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }

}
