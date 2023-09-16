using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryAd { get; set; }
        public string Imgurl { get; set; }
        [Display(Name = "Product Image")]
        public IFormFile CategoryImage { get; set; }

        public List<Product> Products { get; set; }
    }
}
