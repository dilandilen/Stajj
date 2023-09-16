using Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class SaleTransactionModel
    {
        public int SalesId { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Personel is required.")]
        public int PersonelId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
