using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
    public class ProductTransferDAL
    {
        private readonly AppDbContext _context;

        public ProductTransferDAL(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductTransfer> GetAllTransfers()
        {
            return _context.ProductTransfers.ToList();
        }

        public void AddTransfer(ProductTransfer transfer)
        {
            transfer.Date = DateTime.Now;
            _context.ProductTransfers.Add(transfer);
            _context.SaveChanges();
        }

        public void UpdateTransfer(ProductTransfer transfer)
        {
            _context.ProductTransfers.Update(transfer);
            _context.SaveChanges();
        }

        public void DeleteTransfer(int id)
        {
            var transfer = _context.ProductTransfers
                .FirstOrDefault(t => t.ProductTransferId == id);
            if (transfer != null)
            {
                _context.ProductTransfers.Remove(transfer);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Where(p => p.IsActive)
                .ToList();
        }

        public void AddDetail(ProductTransferDetail detail)
        {
            _context.ProductTransferDetails.Add(detail);
            _context.SaveChanges();
        }

        public List<ProductTransferDetail> GetDetailsByTransferId(int transferId)
        {
            return _context.ProductTransferDetails
                .Include(d => d.Product)
                .Where(d => d.ProductTransferId == transferId)
                .ToList();
        }

        public void DeleteDetail(int detailId)
        {
            var detail = _context.ProductTransferDetails
                .FirstOrDefault(d => d.DetailId == detailId);
            if (detail != null)
            {
                _context.ProductTransferDetails.Remove(detail);
                _context.SaveChanges();
            }
        }
    }
}