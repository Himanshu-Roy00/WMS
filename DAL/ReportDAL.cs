using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
    public class ReportDAL
    {
        private readonly AppDbContext _context;

        public ReportDAL(AppDbContext context)
        {
            _context = context;
        }

        // Stock Report
        public List<ProductStock> GetStockReport()
        {
            return _context.ProductStocks
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .ToList();
        }

        // StockIn Report
        public List<StockIn> GetStockInReport()
        {
            return _context.StockIns
                .Include(s => s.Product)
                .Include(s => s.Supplier)
                .Include(s => s.Warehouse)
                .ToList();
        }

        // StockOut Report
        public List<StockOut> GetStockOutReport()
        {
            return _context.StockOuts
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .ToList();
        }

        // Transfer Report
        public List<ProductTransfer> GetTransferReport()
        {
            return _context.ProductTransfers
                .Include(t => t.Details)
                    .ThenInclude(d => d.Product)
                .ToList();
        }
    }
}