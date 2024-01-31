using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Web.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int ExpenseCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Expense Category")]
        public string ExpenseCategoryName { get; set; }
    }
}
