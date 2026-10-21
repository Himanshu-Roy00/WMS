using Microsoft.AspNetCore.Mvc;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
	public class UOMController : Controller
	{
		private readonly UOMBAL _uomBAL;

		public UOMController(UOMBAL uomBAL)
		{
			_uomBAL = uomBAL;
		}

		public IActionResult UOM()
		{
			var uoms = _uomBAL.GetAllUOMs();
			return View(uoms);
		}

		[HttpPost]
		public IActionResult Add(UOM uom)
		{
			uom.IsActive = true;
			_uomBAL.AddUOM(uom);
			return RedirectToAction("UOM");
		}

		[HttpPost]
		public IActionResult Edit(UOM uom)
		{
			_uomBAL.UpdateUOM(uom);
			return RedirectToAction("UOM");
		}

		public IActionResult Delete(int id)
		{
			_uomBAL.DeleteUOM(id);
			return RedirectToAction("UOM");
		}
	}
}