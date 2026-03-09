using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Models;
using System.Diagnostics;

namespace MoneyManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var incomes = await _context.Incomes.ToListAsync();
            var expenses = await _context.Expenses.Include(e => e.Category).ToListAsync();

            var viewModel = new DashboardViewModel
            {
                TotalIncome = incomes.Sum(i => i.Amount),
                TotalExpenses = expenses.Sum(e => e.Amount),
                RecentIncomes = incomes.OrderByDescending(i => i.Date).Take(5).ToList(),
                RecentExpenses = expenses.OrderByDescending(e => e.Date).Take(5).ToList(),
                CategoryBreakdown = expenses.GroupBy(e => e.Category)
                    .Select(g => new CategorySummary
                    {
                        CategoryName = g.Key?.Name ?? "Other",
                        Amount = g.Sum(e => e.Amount),
                        Color = g.Key?.Color ?? "#999999",
                        Percentage = (double)(expenses.Sum(e => e.Amount) > 0 ? (g.Sum(e => e.Amount) / expenses.Sum(e => e.Amount) * 100) : 0)
                    }).ToList()
            };

            return View(viewModel);
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
