using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Managers
{
    public interface ICategoryManager
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(string userId);
        Task<Category?> GetCategoryByIdAsync(int id, string userId);
    }
}
