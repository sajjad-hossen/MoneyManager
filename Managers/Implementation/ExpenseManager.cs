using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;
using MoneyManager.Repositories;

namespace MoneyManager.Managers
{
    public class ExpenseManager : IExpenseManager
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseManager(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesWithCategoryAsync(string userId)
        {
            return await _expenseRepository.GetAllWithCategoryAsync(userId);
        }

        public async Task<Expense?> GetExpenseByIdWithCategoryAsync(int id, string userId)
        {
            var expense = await _expenseRepository.GetByIdWithCategoryAsync(id);
            return expense?.UserId == userId ? expense : null;
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id, string userId)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            return expense?.UserId == userId ? expense : null;
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense, string userId)
        {
            expense.UserId = userId;
            return await _expenseRepository.AddAsync(expense);
        }

        public async Task UpdateExpenseAsync(Expense expense, string userId)
        {
            expense.UserId = userId;
            await _expenseRepository.UpdateAsync(expense);
        }

        public async Task DeleteExpenseAsync(int id, string userId)
        {
            var expense = await GetExpenseByIdAsync(id, userId);
            if (expense != null)
            {
                await _expenseRepository.DeleteAsync(expense);
            }
        }

        public bool ExpenseExists(int id, string userId)
        {
            return _expenseRepository.ExistsAsync(e => e.Id == id && e.UserId == userId).GetAwaiter().GetResult();
        }
    }
}
