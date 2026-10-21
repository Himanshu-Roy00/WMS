using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
    public class StockOutController : Controller
    {
        private readonly StockOutBAL _stockOutBAL;

        public StockOutController(StockOutBAL stockOutBAL)
        {
            _stockOutBAL = stockOutBAL;
        }

        public IActionResult StockOut(string search = "")
        {
            var stockOuts = _stockOutBAL.GetAllStockOuts();

            // ✅ Search filter
            if (!string.IsNullOrEmpty(search))
            {
                stockOuts = stockOuts
                    .Where(s => s.Product.ProductName.ToLower()
                    .Contains(search.ToLower()))
                    .ToList();
            }

            ViewBag.Search = search;

            ViewBag.ProductList = _stockOutBAL.GetAllProducts()
                .Select(p => new SelectListItem
                {
                    Value = p.ProductId.ToString(),
                    Text = p.ProductName
                }).ToList();

            ViewBag.WarehouseList = _stockOutBAL.GetAllWarehouses()
                .Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Name
                }).ToList();

            return View(stockOuts);
        }
        // Add - Form submit
        [HttpPost]
        public IActionResult Add(StockOut stockOut)
        {
            _stockOutBAL.AddStockOut(stockOut);
            return RedirectToAction("StockOut");
        }

        // Edit - Form submit
        [HttpPost]
        public IActionResult Edit(StockOut stockOut)
        {
            _stockOutBAL.UpdateStockOut(stockOut);
            return RedirectToAction("StockOut");
        }

        // Delete
        public IActionResult Delete(int id)
        {
            _stockOutBAL.DeleteStockOut(id);
            return RedirectToAction("StockOut");
        }
    }
}