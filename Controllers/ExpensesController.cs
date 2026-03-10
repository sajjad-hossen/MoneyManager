using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Managers;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseManager _expenseManager;
        private readonly ICategoryManager _categoryManager;

        public ExpensesController(IExpenseManager expenseManager, ICategoryManager categoryManager)
        {
            _expenseManager = expenseManager;
            _categoryManager = categoryManager;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseManager.GetAllExpensesWithCategoryAsync();
            return View(expenses);
        }

        // GET: Expenses/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllCategoriesAsync(), "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Description,Date,CategoryId,Note")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expenseManager.CreateExpenseAsync(expense);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllCategoriesAsync(), "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var expense = await _expenseManager.GetExpenseByIdAsync(id.Value);
            if (expense == null) return NotFound();
            
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllCategoriesAsync(), "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Description,Date,CategoryId,Note")] Expense expense)
        {
            if (id != expense.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _expenseManager.UpdateExpenseAsync(expense);
                }
                catch (Exception)
                {
                    if (!_expenseManager.ExpenseExists(expense.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllCategoriesAsync(), "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var expense = await _expenseManager.GetExpenseByIdWithCategoryAsync(id.Value);
            if (expense == null) return NotFound();

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _expenseManager.DeleteExpenseAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
