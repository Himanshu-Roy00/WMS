namespace WMS.Models
{
	public class StockOut
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public string? IssuedTo { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public string? Remarks { get; set; }

		// Foreign Keys
		public int ProductId { get; set; }
		public int WarehouseId { get; set; }

		// Navigation
		public Product Product { get; set; }
		public Warehouse Warehouse { get; set; }
	}
}