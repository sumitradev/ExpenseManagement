using ExpenseManagement.Web.DataLayer;
using ExpenseManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Web.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly EmDbContext _context;
        public UserProfileController(EmDbContext context)
        {
            _context = context;
        }

        public IActionResult Login(string UserEmail,string UserPassword)
        {
            ViewBag.LoginStatus = "";

            if(ModelState.IsValid)
            {
                var userCheck = _context.UserProfiles.FirstOrDefault(
                        u=>u.UserEmail== UserEmail && u.UserPassword==UserPassword
                );
                if(userCheck==null) {

                    ViewBag.LoginStatus = "Invalid Login or User not Registered";
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _context.UserProfiles.Add(userProfile);
                _context.SaveChanges();
                return RedirectToAction("Login","UserProfile");
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
