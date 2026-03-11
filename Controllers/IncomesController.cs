using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MoneyManager.Managers;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class IncomesController : Controller

    {
        private readonly IIncomeManager _incomeManager;

        public IncomesController(IIncomeManager incomeManager)
        {
            _incomeManager = incomeManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var incomes = await _incomeManager.GetAllIncomesAsync(userId);
            return View(incomes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Source,Date,Note")] Income income)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
                await _incomeManager.CreateIncomeAsync(income, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var income = await _incomeManager.GetIncomeByIdAsync(id.Value, userId);
            if (income == null) return NotFound();
            
            return View(income);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Source,Date,Note")] Income income)
        {
            if (id != income.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
                try
                {
                    await _incomeManager.UpdateIncomeAsync(income, userId);
                }
                catch (Exception)
                {
                    if (!_incomeManager.IncomeExists(income.Id, userId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var income = await _incomeManager.GetIncomeByIdAsync(id.Value, userId);
            if (income == null) return NotFound();

            return View(income);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            await _incomeManager.DeleteIncomeAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
