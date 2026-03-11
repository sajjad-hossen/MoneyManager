using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Managers
{
    public interface IDashboardManager
    {
        Task<DashboardViewModel> GetDashboardDataAsync(string userId);
    }
}
