using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CategoryListModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
