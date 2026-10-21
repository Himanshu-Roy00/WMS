using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class ProductDAL
	{
		private readonly AppDbContext _context;

		public ProductDAL(AppDbContext context)
		{
			_context = context;
		}

		// Sab products lao
		public List<Product> GetAllProducts()
		{
			return _context.Products
							.Include(p => p.Category)  // ye add karo
							.Where(p => p.IsActive)    // ye add karo
							.ToList();
		}

		// Ek product lao by id
		public Product GetProductById(int id)
		{
			return _context.Products.FirstOrDefault(p => p.ProductId == id);
		}

		// Product add karo
		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public List<UOM> GetAllUOM()
		{
			return _context.UOMs.ToList();
		}

		// Product update karo
		public void UpdateProduct(Product product)
		{
			_context.Products.Update(product);
			_context.SaveChanges();
		}

		// Product delete karo
		public void DeleteProduct(int id)
		{
			var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			if (product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
			}
		}

	   // ✅ 2. Categories lene ka method add karo
		public List<Category> GetAllCategories()
		{
			return _context.Categories
				.Where(c => c.IsActive)
				.ToList();
		}
	}
}


