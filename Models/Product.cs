using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required]
		[StringLength(200)]
		public string ProductName { get; set; }

	
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public int Quantity { get; set; }
		public int MinStockLevel { get; set; }

		public bool IsActive { get; set; } = true;  // Soft delete ke liye

		// Product Model mein
		public int UOMId { get; set; }
		public UOM UOM { get; set; }
	}
}