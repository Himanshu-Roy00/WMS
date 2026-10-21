using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class ProductBAL
	{
		private readonly ProductDAL _productDAL;

		public ProductBAL(ProductDAL productDAL)
		{
			_productDAL = productDAL;
		}

		public List<Product> GetAllProducts()
		{
			return _productDAL.GetAllProducts();
		}

		public Product GetProductById(int id)
		{
			return _productDAL.GetProductById(id);
		}

		public void AddProduct(Product product)
		{
			_productDAL.AddProduct(product);
		}

		public void UpdateProduct(Product product)
		{
			_productDAL.UpdateProduct(product);
		}

		public void DeleteProduct(int id)
		{
			_productDAL.DeleteProduct(id);
		}

		public List<Category> GetAllCategories()
		{
			return _productDAL.GetAllCategories();
		}

		public List<UOM> GetAllUOM()
		{
			return _productDAL.GetAllUOM();
		}
	}

}

