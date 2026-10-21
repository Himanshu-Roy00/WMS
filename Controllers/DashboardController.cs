using Microsoft.AspNetCore.Mvc;
using WMS.BAL;

namespace WMS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardBAL _dashboardBAL;

        public DashboardController(DashboardBAL dashboardBAL)
        {
            _dashboardBAL = dashboardBAL;
        }

        public IActionResult AdminDashboard()
        {
            ViewBag.TotalProducts = _dashboardBAL.GetTotalProducts();
            ViewBag.TotalWarehouses = _dashboardBAL.GetTotalWarehouses();
            ViewBag.TotalStockIn = _dashboardBAL.GetTotalStockIn();
            ViewBag.TotalStockOut = _dashboardBAL.GetTotalStockOut();
            ViewBag.TotalTransfers = _dashboardBAL.GetTotalTransfers();
            ViewBag.LowStockProducts = _dashboardBAL.GetLowStockProducts();
            ViewBag.RecentStockIn = _dashboardBAL.GetRecentStockIn();
            ViewBag.RecentStockOut = _dashboardBAL.GetRecentStockOut();
            ViewBag.WarehouseStock = _dashboardBAL.GetWarehouseStock();

            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}