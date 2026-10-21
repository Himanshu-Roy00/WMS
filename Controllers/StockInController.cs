using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
	public class StockInController : Controller
	{
		private readonly StockInBAL _stockInBAL;
		private readonly ProductBAL _productBAL;
		private readonly SupplierBAL _supplierBAL;
		private readonly WarehouseBAL _warehouseBAL;

		public StockInController(
			StockInBAL stockInBAL,
			ProductBAL productBAL,
			SupplierBAL supplierBAL,
			WarehouseBAL warehouseBAL)
		{
			_stockInBAL = stockInBAL;
			_productBAL = productBAL;
			_supplierBAL = supplierBAL;
			_warehouseBAL = warehouseBAL;
		}

       
        public IActionResult StockIn(string search = "")
        {
            ViewBag.ProductList = new SelectList(
                _productBAL.GetAllProducts(),
                "ProductId",
                "ProductName");

            ViewBag.SupplierList = new SelectList(
                _supplierBAL.GetAllSuppliers(),
                "Id",
                "Name");

            ViewBag.WarehouseList = new SelectList(
                _warehouseBAL.GetAllWarehouses(),
                "Id",
                "Name");

            var data = _stockInBAL.GetAllStockIn();

            // ✅ Search filter
            if (!string.IsNullOrEmpty(search))
            {
                data = data
                    .Where(s => s.Product.ProductName.ToLower()
                    .Contains(search.ToLower()))
                    .ToList();
            }

            ViewBag.Search = search;
            return View(data);
        }

        // ADD
        [HttpPost]
		public IActionResult Add(StockIn stockIn)
		{
			_stockInBAL.AddStockIn(stockIn);

			return RedirectToAction("StockIn");
		}

		// EDIT
		[HttpPost]
		public IActionResult Edit(StockIn stockIn)
		{
			_stockInBAL.UpdateStockIn(stockIn);

			return RedirectToAction("StockIn");
		}

		// DELETE
		public IActionResult Delete(int id)
		{
			_stockInBAL.DeleteStockIn(id);

			return RedirectToAction("StockIn");
		}
	}
}