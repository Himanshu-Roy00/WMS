namespace WMS.Models
{
	public class Inventory
	{
		public int Id { get; set; }
		public int Quantity { get; set; } = 0;
		public DateTime LastUpdated { get; set; } = DateTime.Now;

		// Foreign Keys
		public int ProductId { get; set; }
		public int WarehouseId { get; set; }

		// Navigation
		public Product Product { get; set; }
		public Warehouse Warehouse { get; set; }
	}
}