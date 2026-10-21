using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class StockInBAL
	{
		private readonly StockInDAL _stockInDAL;

		public StockInBAL(StockInDAL stockInDAL)
		{
			_stockInDAL = stockInDAL;
		}

		// Get All
		public List<StockIn> GetAllStockIn()
		{
			return _stockInDAL.GetAllStockIn();
		}

		// Add
		public void AddStockIn(StockIn stockIn)
		{
			_stockInDAL.AddStockIn(stockIn);
		}

		// Update
		public void UpdateStockIn(StockIn stockIn)
		{
			_stockInDAL.UpdateStockIn(stockIn);
		}

		// Delete
		public void DeleteStockIn(int id)
		{
			_stockInDAL.DeleteStockIn(id);
		}

		// Get By Id
		public StockIn GetStockInById(int id)
		{
			return _stockInDAL.GetStockInById(id);
		}
	}
}