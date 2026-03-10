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

        public async Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            return await _incomeRepository.GetAllAsync();
        }

        public async Task<Income?> GetIncomeByIdAsync(int id)
        {
            return await _incomeRepository.GetByIdAsync(id);
        }

        public async Task<Income> CreateIncomeAsync(Income income)
        {
            return await _incomeRepository.AddAsync(income);
        }

        public async Task UpdateIncomeAsync(Income income)
        {
            await _incomeRepository.UpdateAsync(income);
        }

        public async Task DeleteIncomeAsync(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            if (income != null)
            {
                await _incomeRepository.DeleteAsync(income);
            }
        }

        public bool IncomeExists(int id)
        {
            return _incomeRepository.ExistsAsync(i => i.Id == id).GetAwaiter().GetResult();
        }
    }
}
