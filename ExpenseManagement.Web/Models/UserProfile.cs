using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Web.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please put a valid Email Address")]
        [EmailAddress]
        [Display(Name ="Email Address")] 
        public string UserEmail { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is mandatory")]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

    }
}
