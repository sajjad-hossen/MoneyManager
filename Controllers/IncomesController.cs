using Microsoft.AspNetCore.Mvc;
using MoneyManager.Managers;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class IncomesController : Controller
    {
        private readonly IIncomeManager _incomeManager;

        public IncomesController(IIncomeManager incomeManager)
        {
            _incomeManager = incomeManager;
        }

        // GET: Incomes
        public async Task<IActionResult> Index()
        {
            var incomes = await _incomeManager.GetAllIncomesAsync();
            return View(incomes);
        }

        // GET: Incomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incomes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Source,Date,Note")] Income income)
        {
            if (ModelState.IsValid)
            {
                await _incomeManager.CreateIncomeAsync(income);
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        // GET: Incomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var income = await _incomeManager.GetIncomeByIdAsync(id.Value);
            if (income == null) return NotFound();
            
            return View(income);
        }

        // POST: Incomes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Source,Date,Note")] Income income)
        {
            if (id != income.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _incomeManager.UpdateIncomeAsync(income);
                }
                catch (Exception)
                {
                    if (!_incomeManager.IncomeExists(income.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        // GET: Incomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var income = await _incomeManager.GetIncomeByIdAsync(id.Value);
            if (income == null) return NotFound();

            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _incomeManager.DeleteIncomeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
