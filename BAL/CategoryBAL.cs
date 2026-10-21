using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class CategoryBAL
	{
		private readonly CategoryDAL _categoryDAL;

		public CategoryBAL(CategoryDAL categoryDAL)
		{
			_categoryDAL = categoryDAL;
		}

		public List<Category> GetAllCategories()
		{
			return _categoryDAL.GetAllCategories();
		}

		public void AddCategory(Category category)
		{
			_categoryDAL.AddCategory(category);
		}

		public void UpdateCategory(Category category)
		{
			_categoryDAL.UpdateCategory(category);
		}
		public void DeleteCategory(int id)
		{
			_categoryDAL.DeleteCategory(id);
		}
	}
}