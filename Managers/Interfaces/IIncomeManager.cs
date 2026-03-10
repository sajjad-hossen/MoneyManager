using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Managers
{
    public interface IIncomeManager
    {
        Task<IEnumerable<Income>> GetAllIncomesAsync();
        Task<Income?> GetIncomeByIdAsync(int id);
        Task<Income> CreateIncomeAsync(Income income);
        Task UpdateIncomeAsync(Income income);
        Task DeleteIncomeAsync(int id);
        bool IncomeExists(int id);
    }
}
