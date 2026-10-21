using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
    public class ProductTransfer
    {
        [Key]
        public int ProductTransferId { get; set; }
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }

        public ICollection<ProductTransferDetail>? Details { get; set; }
    }
}