using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class OrderModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
   
        public CartModel CartModel { get; set; }
    }
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CartItemModel> cartItems { get; set; }
    }
}
