using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
    public class StockOutDAL
    {
        private readonly AppDbContext _context;

        public StockOutDAL(AppDbContext context)
        {
            _context = context;
        }

        // Sab StockOut lao
        public List<StockOut> GetAllStockOuts()
        {
            return _context.StockOuts
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .ToList();
        }

        // Ek StockOut lao by id
        public StockOut GetStockOutById(int id)
        {
            return _context.StockOuts
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .FirstOrDefault(s => s.Id == id);
        }

        public void AddStockOut(StockOut stockOut)
        {
            stockOut.Date = DateTime.Now;
            _context.StockOuts.Add(stockOut);
            _context.SaveChanges();

            // ✅ ProductStock auto-update
            var stock = _context.ProductStocks
                .FirstOrDefault(s => s.ProductId == stockOut.ProductId
                                  && s.WarehouseId == stockOut.WarehouseId);

            if (stock != null)
            {
                // Quantity kam karo
                stock.Quantity -= stockOut.Quantity;
                stock.LastUpdated = DateTime.Now;
                _context.ProductStocks.Update(stock);
                _context.SaveChanges();
            }
        }

        // StockOut update karo
        public void UpdateStockOut(StockOut stockOut)
        {
            _context.StockOuts.Update(stockOut);
            _context.SaveChanges();
        }

        // StockOut delete karo
        public void DeleteStockOut(int id)
        {
            var stockOut = _context.StockOuts
                .FirstOrDefault(s => s.Id == id);
            if (stockOut != null)
            {
                _context.StockOuts.Remove(stockOut);
                _context.SaveChanges();
            }
        }

        // Products list
        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Where(p => p.IsActive)
                .ToList();
        }

        // Warehouses list
        public List<Warehouse> GetAllWarehouses()
        {
            return _context.Warehouses.ToList();
        }
    }
}