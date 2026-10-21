using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
	public class Supplier
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public string? Address { get; set; }


		// Navigation
		public ICollection<Product>? Products { get; set; }

		public ICollection<StockIn>? StockIns { get; set; }
	}
}