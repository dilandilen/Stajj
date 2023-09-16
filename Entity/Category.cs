using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CategoryName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string?   Imgurl { get; set; }
       public List<ProductCategory> ProductCategories { get; set; }
    }
}

