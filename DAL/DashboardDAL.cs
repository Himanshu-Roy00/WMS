using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
    public class DashboardDAL
    {
        private readonly AppDbContext _context;

        public DashboardDAL(AppDbContext context)
        {
            _context = context;
        }

        public int GetTotalProducts()
        {
            return _context.Products.Count(p => p.IsActive);
        }

        public int GetTotalWarehouses()
        {
            return _context.Warehouses.Count();
        }

        public int GetTotalStockIn()
        {
            return _context.StockIns.Count();
        }

        public int GetTotalStockOut()
        {
            return _context.StockOuts.Count();
        }

        public int GetTotalTransfers()
        {
            return _context.ProductTransfers.Count();
        }

        public List<Product> GetLowStockProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive && p.Quantity <= p.MinStockLevel)
                .ToList();
        }

        public List<StockIn> GetRecentStockIn()
        {
            return _context.StockIns
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .Include(s => s.Supplier)
                .OrderByDescending(s => s.Date)
                .Take(5)
                .ToList();
        }

        public List<StockOut> GetRecentStockOut()
        {
            return _context.StockOuts
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .OrderByDescending(s => s.Date)
                .Take(5)
                .ToList();
        }

        public List<ProductStock> GetWarehouseStock()
        {
            return _context.ProductStocks
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .ToList();
        }
    }
}