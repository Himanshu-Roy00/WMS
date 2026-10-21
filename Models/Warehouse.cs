namespace WMS.Models
{
	public class Warehouse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Location { get; set; }
		public int Capacity { get; set; }

		// Navigation
		public ICollection<Inventory> Inventories { get; set; }
		public ICollection<StockIn> StockIns { get; set; }
		public ICollection<StockOut> StockOuts { get; set; }
	}
}