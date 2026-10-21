using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class CategoryDAL
	{
		private readonly AppDbContext _context;

		public CategoryDAL(AppDbContext context)
		{
			_context = context;
		}

		public List<Category> GetAllCategories()
		{
			return _context.Categories
				.Where(c => c.IsActive)
				.ToList();
		}

		public void AddCategory(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
		}

		public void UpdateCategory(Category category)
		{
			var existing = _context.Categories.Find(category.CategoryId);
			if (existing != null)
			{
				existing.CategoryName = category.CategoryName;
				_context.SaveChanges();
			}
		}

		public void DeleteCategory(int id)
		{
			var cat = _context.Categories.Find(id);
			if (cat != null)
			{
				cat.IsActive = false; // Soft delete
				_context.SaveChanges();
			}
		}
	}
}