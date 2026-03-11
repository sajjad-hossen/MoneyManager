using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models;
using MoneyManager.Repositories;

namespace MoneyManager.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(string userId)
        {
            return await _categoryRepository.FindAsync(c => c.UserId == userId || c.UserId == null);
        }

        public async Task<Category?> GetCategoryByIdAsync(int id, string userId)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return (category?.UserId == userId || category?.UserId == null) ? category : null;
        }
    }
}
