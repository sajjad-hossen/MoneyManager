using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Managers
{
    public interface IExpenseManager
    {
        Task<IEnumerable<Expense>> GetAllExpensesWithCategoryAsync();
        Task<Expense?> GetExpenseByIdWithCategoryAsync(int id);
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<Expense> CreateExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
        bool ExpenseExists(int id);
    }
}
