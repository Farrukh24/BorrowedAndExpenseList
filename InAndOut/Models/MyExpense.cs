using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class MyExpense
    {
        [Key]
        public int ExpenseId { get; set; }
        
        // the name of item        
        [DisplayName ("Expense name")]
        [Required]
        public string ExpenseName { get; set; }

        // amount of spending money     
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Ammount must be greater than 0!")]
        public int Amount { get; set; }
    }
}
