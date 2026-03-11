using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Managers
{
    public interface IExpenseManager
    {
        Task<IEnumerable<Expense>> GetAllExpensesWithCategoryAsync(string userId);
        Task<Expense?> GetExpenseByIdWithCategoryAsync(int id, string userId);
        Task<Expense?> GetExpenseByIdAsync(int id, string userId);
        Task<Expense> CreateExpenseAsync(Expense expense, string userId);
        Task UpdateExpenseAsync(Expense expense, string userId);
        Task DeleteExpenseAsync(int id, string userId);
        bool ExpenseExists(int id, string userId);
    }
}
