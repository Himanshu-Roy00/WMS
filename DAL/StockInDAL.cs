using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class StockInDAL
	{
		private readonly AppDbContext _context;

		public StockInDAL(AppDbContext context)
		{
			_context = context;
		}

		// Get All
		public List<StockIn> GetAllStockIn()
		{
			return _context.StockIns
				.Include(x => x.Product)
				.Include(x => x.Supplier)
				.Include(x => x.Warehouse)
				.ToList();
		}

        // Add
        public void AddStockIn(StockIn stockIn)
        {
            _context.StockIns.Add(stockIn);
            _context.SaveChanges();

            // ✅ ProductStock auto-update
            var stock = _context.ProductStocks
                .FirstOrDefault(s => s.ProductId == stockIn.ProductId
                                  && s.WarehouseId == stockIn.WarehouseId);

            if (stock != null)
            {
                // Record exist karta hai — quantity badhaoo
                stock.Quantity += stockIn.Quantity;
                stock.LastUpdated = DateTime.Now;
                _context.ProductStocks.Update(stock);
            }
            else
            {
                // Naya record banao
                var newStock = new ProductStock
                {
                    ProductId = stockIn.ProductId,
                    WarehouseId = stockIn.WarehouseId,
                    Quantity = stockIn.Quantity,
                    LastUpdated = DateTime.Now
                };
                _context.ProductStocks.Add(newStock);
            }

            _context.SaveChanges();
        }




        // Update
        public void UpdateStockIn(StockIn stockIn)
		{
			_context.StockIns.Update(stockIn);
			_context.SaveChanges();
		}

		// Delete
		public void DeleteStockIn(int id)
		{
			var data = _context.StockIns.Find(id);

			if (data != null)
			{
				_context.StockIns.Remove(data);
				_context.SaveChanges();
			}
		}

		// Get By Id
		public StockIn GetStockInById(int id)
		{
			return _context.StockIns.Find(id);
		}
	}
}