using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
	public class ProductController : Controller
	{
		private readonly ProductBAL _productBAL;

		public ProductController(ProductBAL productBAL)
		{
			_productBAL = productBAL;
		}


        public IActionResult Product(string search = "")
        {
            var products = _productBAL.GetAllProducts();

            // ✅ Search filter
            if (!string.IsNullOrEmpty(search))
            {
                products = products
                    .Where(p => p.ProductName.ToLower()
                    .Contains(search.ToLower()))
                    .ToList();
            }

            ViewBag.Search = search;

            ViewBag.CategoryList = _productBAL.GetAllCategories()
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList();

            ViewBag.UOMList = _productBAL.GetAllUOM()
                .Select(u => new SelectListItem
                {
                    Value = u.UOMId.ToString(),
                    Text = u.UOMName
                }).ToList();

            return View(products);
        }


        // ✅ Ye add karo Controller mein
        public IActionResult Add()
		{
			ViewBag.CategoryList = _productBAL.GetAllCategories()
				.Select(c => new SelectListItem
				{
					Value = c.CategoryId.ToString(),
					Text = c.CategoryName
				}).ToList();

			// ✅ Add This
			ViewBag.UOMList = _productBAL.GetAllUOM()
				.Select(u => new SelectListItem
				{
					Value = u.UOMId.ToString(),
					Text = u.UOMName
				}).ToList();

			return View();
		}


		// Add - Form submit
		[HttpPost]
		public IActionResult Add(Product product)
		{
			Console.WriteLine("UOMId: " + product.UOMId);
			var cat = product.CategoryId;
			_productBAL.AddProduct(product);
			return RedirectToAction("Product");
		}



		// Edit - Form submit
		[HttpPost]
		public IActionResult Edit(Product product)
		{
			_productBAL.UpdateProduct(product);
			return RedirectToAction("Product");
		}

		// Delete
		public IActionResult Delete(int id)
		{
			_productBAL.DeleteProduct(id);
			return RedirectToAction("Product");
		}
	}
}