using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity

{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }  
        public string Expensedesc { get; set;}
        public DateTime ExpenseDate { get; set; }
        public int ExpenseAmount { get; set; }
    }
}
