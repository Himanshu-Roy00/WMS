using Microsoft.AspNetCore.Mvc.Rendering;

namespace WMS.Models
{
	public class ProductViewModel
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int CategoryId { get; set; }
		public int Quantity { get; set; }
		public int MinStockLevel { get; set; }

		public List<Product> Products { get; set; }

		public List<SelectListItem> CategoryList { get; set; }
	}
}