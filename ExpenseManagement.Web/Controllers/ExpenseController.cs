using ExpenseManagement.Web.DataLayer;
using ExpenseManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly EmDbContext _context;

        public ExpenseController(EmDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenseList = _context.Expenses.ToList();
            foreach(var obj in expenseList)
            {
                obj.ExpenseCategory = _context.ExpensesCategories.FirstOrDefault(u => u.ExpenseCategoryId== obj.ExpenseCategoryId);
            }
            return View(expenseList);
        }

        public IActionResult Create() 
        {
            IEnumerable<SelectListItem> getExpenseCate = _context.ExpensesCategories.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategoryName,
                Value = i.ExpenseCategoryId.ToString()
            });
            ViewBag.PopulateExpenseCate = getExpenseCate;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expenseDetails)
        {
          
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        
        public IActionResult GetExpenseDetailsForUpdate(int? Id)
        {

            var _expenseDetails = _context.Expenses.Find(Id);

            IEnumerable<SelectListItem> expenseCategory = _context.ExpensesCategories.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategoryName,
                Value = i.ExpenseCategoryId.ToString()
            });

            ViewBag.ExpenseCategory = expenseCategory;

            if(_expenseDetails==null)
            {
                return NotFound();
            }
            return View(_expenseDetails);
            
        }

        [HttpPost]
        public IActionResult Update(Expense expenseDetails)
        {
            if(ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseDetailsForDelete(int? Id)
        {

            var _expenseDetails = _context.Expenses.Find(Id);

            if (_expenseDetails == null)
            {
                return NotFound();
            }
            return View(_expenseDetails);

        }
        [HttpPost]
        public IActionResult Delete(int? ExpenseId)
        {
            var _expenseDetails = _context.Expenses.Find(ExpenseId);

            if (_expenseDetails == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(_expenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
