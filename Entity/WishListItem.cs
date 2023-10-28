using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  

    public class WishlistItem
    {

        public int Id { get; set; }
        public int ProductId { get; set; } 
        public int WishlistId { get; set; } 
        public DateTime AddedAt { get; set; } 
        
        public Product Product { get; set; }
    }

}
