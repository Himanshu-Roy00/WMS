using Microsoft.AspNetCore.Mvc;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
	public class SupplierController : Controller
	{
		private readonly SupplierBAL _supplierBAL;

		public SupplierController(SupplierBAL supplierBAL)
		{
			_supplierBAL = supplierBAL;
		}

        // LIST
        public IActionResult Supplier(string search = "")
        {
            var suppliers = _supplierBAL.GetAllSuppliers();

            if (!string.IsNullOrEmpty(search))
            {
                suppliers = suppliers
                    .Where(s => s.Name.ToLower()
                    .Contains(search.ToLower()))
                    .ToList();
            }

            ViewBag.Search = search;
            return View(suppliers);
        }

        // ADD
        [HttpPost]
		public IActionResult Add(Supplier supplier)
		{
			_supplierBAL.AddSupplier(supplier);

			return RedirectToAction("Supplier");
		}

		// EDIT
		[HttpPost]
		public IActionResult Edit(Supplier supplier)
		{
			_supplierBAL.UpdateSupplier(supplier);

			return RedirectToAction("Supplier");
		}

		// DELETE
		public IActionResult Delete(int id)
		{
			_supplierBAL.DeleteSupplier(id);

			return RedirectToAction("Supplier");
		}
	}
}