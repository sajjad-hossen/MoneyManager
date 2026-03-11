using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;
using MoneyManager.Repositories;

namespace MoneyManager.Managers
{
    public class IncomeManager : IIncomeManager
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeManager(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<IEnumerable<Income>> GetAllIncomesAsync(string userId)
        {
            return await _incomeRepository.FindAsync(i => i.UserId == userId);
        }

        public async Task<Income?> GetIncomeByIdAsync(int id, string userId)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            return income?.UserId == userId ? income : null;
        }

        public async Task<Income> CreateIncomeAsync(Income income, string userId)
        {
            income.UserId = userId;
            return await _incomeRepository.AddAsync(income);
        }

        public async Task UpdateIncomeAsync(Income income, string userId)
        {
            income.UserId = userId;
            await _incomeRepository.UpdateAsync(income);
        }

        public async Task DeleteIncomeAsync(int id, string userId)
        {
            var income = await GetIncomeByIdAsync(id, userId);
            if (income != null)
            {
                await _incomeRepository.DeleteAsync(income);
            }
        }

        public bool IncomeExists(int id, string userId)
        {
            return _incomeRepository.ExistsAsync(i => i.Id == id && i.UserId == userId).GetAwaiter().GetResult();
        }
    }
}
