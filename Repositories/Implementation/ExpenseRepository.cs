using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Models;
using System.Threading.Tasks;
namespace MoneyManager.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Expense>> GetAllWithCategoryAsync(string userId)
        {
            return await _dbSet.Include(e => e.Category).Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<Expense?> GetByIdWithCategoryAsync(int id)
        {
            return await _dbSet.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
