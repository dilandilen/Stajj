using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ProductModel
    {
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

        [Display(Name = "Product Image")]
        public IFormFile ProductImage { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
        public List<Category> SelectedCategories { get; set; }
        public int[] SelectedCategoryIds { get; set; }


    }
}