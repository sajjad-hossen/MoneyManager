using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Data;
using MoneyManager.Models;
namespace MoneyManager.Repositories
{
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
