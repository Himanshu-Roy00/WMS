using Microsoft.AspNetCore.Mvc;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
	public class CategoryController : Controller
	{
		private readonly CategoryBAL _categoryBAL;

		public CategoryController(CategoryBAL categoryBAL)
		{
			_categoryBAL = categoryBAL;
		}

		// List
		public IActionResult Category()
		{
			var categories = _categoryBAL.GetAllCategories();
			return View(categories);
		}

		// Add
		[HttpPost]
		public IActionResult Add(Category category)
		{
			category.IsActive = true;
			_categoryBAL.AddCategory(category);
			return RedirectToAction("Category");
		}

		// Edit
		[HttpPost]
		public IActionResult Edit(Category category)
		{
			_categoryBAL.UpdateCategory(category);
			return RedirectToAction("Category");
		}
		// Delete
		public IActionResult Delete(int id)
		{
			_categoryBAL.DeleteCategory(id);
			return RedirectToAction("Category");
		}
	}
}