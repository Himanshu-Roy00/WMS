using Microsoft.AspNetCore.Mvc;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
	public class WarehouseController : Controller
	{
		private readonly WarehouseBAL _warehouseBAL;

		public WarehouseController(WarehouseBAL warehouseBAL)
		{
			_warehouseBAL = warehouseBAL;
		}

		// LIST
		public IActionResult Warehouse()
		{
			var warehouses = _warehouseBAL.GetAllWarehouses();

			return View(warehouses);
		}

		// ADD
		[HttpPost]
		public IActionResult Add(Warehouse warehouse)
		{
			_warehouseBAL.AddWarehouse(warehouse);

			return RedirectToAction("Warehouse");
		}

		// EDIT
		[HttpPost]
		public IActionResult Edit(Warehouse warehouse)
		{
			_warehouseBAL.UpdateWarehouse(warehouse);

			return RedirectToAction("Warehouse");
		}

		// DELETE
		public IActionResult Delete(int id)
		{
			_warehouseBAL.DeleteWarehouse(id);

			return RedirectToAction("Warehouse");
		}
	}
}