using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string ProductName { get; set; }

    
        

        public int Stock { get; set; }
        public decimal Cost_price { get; set; }
        public decimal Selling_price { get; set; }
        public bool State { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string imgurl { get; set; }
       
        public string Brandname { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }


    }
}

