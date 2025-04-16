using Microsoft.AspNetCore.Mvc;
using MyHomeBudget.Data;
using MyHomeBudget.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace MyHomeBudget.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyHomeBudgetContext _context;

        public LoginController(MyHomeBudgetContext context)
        {
            _context = context;
            
            if (!_context.Users.Any())
            {
                var user = new User
                {
                    Name = "Turaqulova Shaxnoza",
                    Login = "admin",
                    Password = "123456"
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        // GET: /Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Login yoki parol xato!";
            return View();
        }

        // GET: /Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
