using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string?  UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set;}
        public string Adress {get;set;}
        public bool IsDelete { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }

	}
}
