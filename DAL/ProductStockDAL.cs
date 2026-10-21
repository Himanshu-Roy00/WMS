using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
    public class ProductStockDAL
    {
        private readonly AppDbContext _context;

        public ProductStockDAL(AppDbContext context)
        {
            _context = context;
        }

        // Sab stocks lao
        public List<ProductStock> GetAllStocks()
        {
            return _context.ProductStocks
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .ToList();
        }

        // Ek stock lao by id
        public ProductStock GetStockById(int id)
        {
            return _context.ProductStocks
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .FirstOrDefault(s => s.StockId == id);
        }

        // Stock add karo
        public void AddStock(ProductStock stock)
        {
            stock.LastUpdated = DateTime.Now;
            _context.ProductStocks.Add(stock);
            _context.SaveChanges();
        }

        // Stock update karo
        public void UpdateStock(ProductStock stock)
        {
            stock.LastUpdated = DateTime.Now;
            _context.ProductStocks.Update(stock);
            _context.SaveChanges();
        }

        // Stock delete karo
        public void DeleteStock(int id)
        {
            var stock = _context.ProductStocks
                .FirstOrDefault(s => s.StockId == id);
            if (stock != null)
            {
                _context.ProductStocks.Remove(stock);
                _context.SaveChanges();
            }
        }

        // Products list lao
        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Where(p => p.IsActive)
                .ToList();
        }

        // Warehouses list lao
        public List<Warehouse> GetAllWarehouses()
        {
            return _context.Warehouses.ToList();
        }
    }
}