using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		[Required]
		[StringLength(100)]
		public string CategoryName { get; set; }

		public bool IsActive { get; set; } = true;

		// Navigation Property
		public ICollection<Product> Products { get; set; }
	}
}