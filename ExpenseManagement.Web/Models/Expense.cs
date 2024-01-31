using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Web.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        [Required(ErrorMessage = "Please Select Expense Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }
        [Required(ErrorMessage = "Please enter Expense Given to ")]
        [MinLength(5, ErrorMessage = ("Too Short"))]
        [Display(Name = "Paid To")]
        public string ExpenseGivenTo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter amount")]
        [DataType(DataType.Currency)]
        [Display(Name = "Expense Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Valid Amount please")]
        public double ExpenseAmount { get; set; }

        [Display(Name = "Expense Category")]
        public int ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategory? ExpenseCategory { get; set; }

    }
}
