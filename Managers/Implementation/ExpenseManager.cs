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

        public async Task<IEnumerable<Expense>> GetAllExpensesWithCategoryAsync()
        {
            return await _expenseRepository.GetAllWithCategoryAsync();
        }

        public async Task<Expense?> GetExpenseByIdWithCategoryAsync(int id)
        {
            return await _expenseRepository.GetByIdWithCategoryAsync(id);
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetByIdAsync(id);
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            return await _expenseRepository.AddAsync(expense);
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense != null)
            {
                await _expenseRepository.DeleteAsync(expense);
            }
        }

        public bool ExpenseExists(int id)
        {
            return _expenseRepository.ExistsAsync(e => e.Id == id).GetAwaiter().GetResult();
        }
    }
}
