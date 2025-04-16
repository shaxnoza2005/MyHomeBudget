using Microsoft.AspNetCore.Mvc;
using MyHomeBudget.Data;
using MyHomeBudget.Models;
using Microsoft.EntityFrameworkCore;

namespace MyHomeBudget.Controllers
{
    public class TransactionController : Controller
    {
        private readonly MyHomeBudgetContext _context;

        public TransactionController(MyHomeBudgetContext context)
        {
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
            
            var incomeTotal = transactions
                .Where(t => t.IsIncome)
                .Sum(t => t.Amount);

            var expenseTotal = transactions
                .Where(t => !t.IsIncome)
                .Sum(t => t.Amount);

            var balance = incomeTotal - expenseTotal;
            
            ViewBag.Income = incomeTotal;
            ViewBag.Expense = expenseTotal;
            ViewBag.Balance = balance;

            return View(transactions);
        }
        
        
        [HttpPost]
        public IActionResult AjaxCreate(Transaction transaction)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                transaction.UserId = userId.Value;
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        public IActionResult TransactionList()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return Unauthorized();

            var transactions = _context.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToList();

            return PartialView("_TransactionListPartial", transactions);
        }

        public IActionResult GetCreateForm()
        {
            return PartialView("_CreateFormPartial", new Transaction());
        }


        // ✅ GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Create
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Index", "Login");

            if (ModelState.IsValid)
            {
                transaction.UserId = userId.Value;
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

   
        public IActionResult Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var transaction = _context.Transactions
                .FirstOrDefault(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
                return NotFound();

            return View(transaction);
        }
        
        [HttpPost]
        public IActionResult Edit(Transaction updated)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null || updated.UserId != userId)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                _context.Transactions.Update(updated);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updated);
        }
        
        public IActionResult Delete(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var transaction = _context.Transactions
                .FirstOrDefault(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
                return NotFound();

            return View(transaction);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var transaction = _context.Transactions
                .FirstOrDefault(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
                return NotFound();

            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
