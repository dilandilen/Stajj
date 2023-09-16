using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class ProductCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
