using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public double Total { get; set; }

        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }

        public EnumOrderState OrderState { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }

      
        public List<OrderItem> OrderItems { get; set; }

    }

    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor")]
        Bekleniyor,
        [Display(Name = "Tamamlandı")]
        Tamamlandı,
        [Display(Name = "Paketlendi")]
        Paketlendi,
        [Display(Name = "Kargolandı")]
        Kargolandı
    }

    public enum EnumPaymentTypes
    {
        CreditCart = 0,
        Eft = 1
    }
}
