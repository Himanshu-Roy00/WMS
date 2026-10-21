namespace WMS.Models
{
	public class StockIn
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public decimal PurchasePrice { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public string? Remarks { get; set; }

		// Foreign Keys
		public int ProductId { get; set; }
		public int WarehouseId { get; set; }
		public int SupplierId { get; set; }

		// Navigation
		public Product Product { get; set; }
		public Warehouse Warehouse { get; set; }
		public Supplier Supplier { get; set; }
	}
}