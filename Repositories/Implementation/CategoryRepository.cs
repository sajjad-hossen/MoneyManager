using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Data;
using MoneyManager.Models;
namespace MoneyManager.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
