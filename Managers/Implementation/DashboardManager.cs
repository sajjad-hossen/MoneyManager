using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyManager.Models;
using MoneyManager.Repositories;

namespace MoneyManager.Managers
{
    public class DashboardManager : IDashboardManager
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;

        public DashboardManager(IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
        {
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync(string userId)
        {
            var incomes = (await _incomeRepository.FindAsync(i => i.UserId == userId)).ToList();
            var expenses = (await _expenseRepository.GetAllWithCategoryAsync(userId)).ToList();

            return new DashboardViewModel
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
                        Percentage = (double)(expenses.Sum(e => e.Amount) > 0 
                            ? (g.Sum(e => e.Amount) / expenses.Sum(e => e.Amount) * 100) 
                            : 0)
                    }).ToList()
            };
        }
    }
}
