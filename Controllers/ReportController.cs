using Microsoft.AspNetCore.Mvc;
using WMS.BAL;

namespace WMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportBAL _reportBAL;

        public ReportController(ReportBAL reportBAL)
        {
            _reportBAL = reportBAL;
        }

        // Stock Report
        public IActionResult StockReport()
        {
            var data = _reportBAL.GetStockReport();
            return View(data);
        }

        // StockIn Report
        public IActionResult StockInReport()
        {
            var data = _reportBAL.GetStockInReport();
            return View(data);
        }

        // StockOut Report
        public IActionResult StockOutReport()
        {
            var data = _reportBAL.GetStockOutReport();
            return View(data);
        }

        // Transfer Report
        public IActionResult TransferReport()
        {
            var data = _reportBAL.GetTransferReport();
            return View(data);
        }
    }
}