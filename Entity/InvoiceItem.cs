using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
    public int Amount { get; set; }

    [Column(TypeName = "VarChar")]
    [StringLength(100)]
    public string Description { get; set; }
    public decimal UnitPrice{ get; set; }
public decimal Tutar { get; set; }
public int InvoiceId { get; set; }
public virtual Invoice Invoice { get; set; }
}
    }

