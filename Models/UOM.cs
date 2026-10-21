using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
	public class UOM
	{
		[Key]
		public int UOMId { get; set; }

		public string UOMName { get; set; }

		public string ShortName { get; set; }

		public bool IsActive { get; set; } = true;

		public ICollection<Product> Products { get; set; }
	}
}