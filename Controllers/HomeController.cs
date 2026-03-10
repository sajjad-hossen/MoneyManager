using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Models;
using MoneyManager.Managers;
using System.Diagnostics;

namespace MoneyManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDashboardManager _dashboardManager;

        public HomeController(IDashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _dashboardManager.GetDashboardDataAsync();
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
