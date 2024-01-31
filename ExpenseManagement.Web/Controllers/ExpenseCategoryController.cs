using ExpenseManagement.Web.DataLayer;
using ExpenseManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Web.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly EmDbContext _context;

        public ExpenseCategoryController(EmDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseCategory> expenseCategory = _context.ExpensesCategories.ToList();
           
            return View(expenseCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenseCategory expenseCategory)
        {
            if (expenseCategory == null) 
            {
                return NotFound();
            }
            _context.ExpensesCategories.Add(expenseCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult GetExpenseCategoryDetForUpdate(int? Id)
        {
            var expenseCategory = _context.ExpensesCategories.Find(Id) ;
            if(expenseCategory== null)
            {
                return NotFound();
            }
            return View(expenseCategory); 
        }

        [HttpPost]
        public IActionResult Update(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid) {
                _context.ExpensesCategories.Update(expenseCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult GetExpenseCategoryDetForDelete(int? Id)
        {
            var expenseCat = _context.ExpensesCategories.Find(Id);

            if (expenseCat == null)
            {
                return NotFound();
            }
            return View(expenseCat);
        }

        [HttpPost]
        public IActionResult Delete(int? ExpenseCategoryId)
        {
            var expenseCat = _context.ExpensesCategories.Find(ExpenseCategoryId);
            if(expenseCat == null)
            {
                return NotFound();
            }
            _context.ExpensesCategories.Remove(expenseCat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
