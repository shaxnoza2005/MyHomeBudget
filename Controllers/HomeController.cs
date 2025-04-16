using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyHomeBudget.Models;
using MyHomeBudget.Data;
using Microsoft.EntityFrameworkCore;

namespace MyHomeBudget.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyHomeBudgetContext _context;

        public HomeController(ILogger<HomeController> logger, MyHomeBudgetContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Index", "Login");

            var transactions = _context.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToList();

            ViewBag.Income = transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
            ViewBag.Expense = transactions.Where(t => !t.IsIncome).Sum(t => t.Amount);
            ViewBag.Balance = ViewBag.Income - ViewBag.Expense;

            return View(transactions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
