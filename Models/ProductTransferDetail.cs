using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
    public class ProductTransferDetail
    {
        [Key]
        public int DetailId { get; set; }
        public int ProductTransferId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductTransfer? ProductTransfer { get; set; }
        public Product? Product { get; set; }
    }
}