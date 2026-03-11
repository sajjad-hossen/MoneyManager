using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetAllWithCategoryAsync(string userId);
        Task<Expense?> GetByIdWithCategoryAsync(int id);
    }
}
