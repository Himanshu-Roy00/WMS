using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
    public class ProductStockController : Controller
    {
        private readonly ProductStockBAL _stockBAL;

        public ProductStockController(ProductStockBAL stockBAL)
        {
            _stockBAL = stockBAL;
        }

        // List
        public IActionResult ProductStock()
        {
            var stocks = _stockBAL.GetAllStocks();

            ViewBag.ProductList = _stockBAL.GetAllProducts()
                .Select(p => new SelectListItem
                {
                    Value = p.ProductId.ToString(),
                    Text = p.ProductName
                }).ToList();

            ViewBag.WarehouseList = _stockBAL.GetAllWarehouses()
                .Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Name
                }).ToList();

            return View(stocks);
        }

        // Add - Form show
        public IActionResult Add()
        {
            ViewBag.ProductList = _stockBAL.GetAllProducts()
                .Select(p => new SelectListItem
                {
                    Value = p.ProductId.ToString(),
                    Text = p.ProductName
                }).ToList();

            ViewBag.WarehouseList = _stockBAL.GetAllWarehouses()
                .Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Name
                }).ToList();

            return View();
        }

        // Add - Form submit
        [HttpPost]
        public IActionResult Add(ProductStock stock)
        {
            _stockBAL.AddStock(stock);
            return RedirectToAction("ProductStock");
        }

        // Edit - Form submit
        [HttpPost]
        public IActionResult Edit(ProductStock stock)
        {
            _stockBAL.UpdateStock(stock);
            return RedirectToAction("ProductStock");
        }

        // Delete
        public IActionResult Delete(int id)
        {
            _stockBAL.DeleteStock(id);
            return RedirectToAction("ProductStock");
        }
    }
}