using ExpenseManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Web.DataLayer
{
    public class EmDbContext : DbContext
    {
        public EmDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategories { get; set;}
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
