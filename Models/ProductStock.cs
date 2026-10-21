using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Models
{
    public class ProductStock
    {
        [Key]
        public int StockId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public decimal Quantity { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}