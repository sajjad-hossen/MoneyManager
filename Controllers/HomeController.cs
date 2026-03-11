using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MoneyManager.Data;
using MoneyManager.Models;
using MoneyManager.Managers;
using System.Diagnostics;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDashboardManager _dashboardManager;

        public HomeController(IDashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var viewModel = await _dashboardManager.GetDashboardDataAsync(userId);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
