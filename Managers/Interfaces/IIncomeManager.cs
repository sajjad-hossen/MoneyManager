using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Managers
{
    public interface IIncomeManager
    {
        Task<IEnumerable<Income>> GetAllIncomesAsync(string userId);
        Task<Income?> GetIncomeByIdAsync(int id, string userId);
        Task<Income> CreateIncomeAsync(Income income, string userId);
        Task UpdateIncomeAsync(Income income, string userId);
        Task DeleteIncomeAsync(int id, string userId);
        bool IncomeExists(int id, string userId);
    }
}
