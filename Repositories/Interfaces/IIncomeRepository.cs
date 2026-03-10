using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MoneyManager.Models;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IIncomeRepository : IRepository<Income>
    {
    }
}
