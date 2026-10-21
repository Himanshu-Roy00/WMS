using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
    public class StockOutBAL
    {
        private readonly StockOutDAL _stockOutDAL;

        public StockOutBAL(StockOutDAL stockOutDAL)
        {
            _stockOutDAL = stockOutDAL;
        }

        public List<StockOut> GetAllStockOuts()
        {
            return _stockOutDAL.GetAllStockOuts();
        }

        public StockOut GetStockOutById(int id)
        {
            return _stockOutDAL.GetStockOutById(id);
        }

        public void AddStockOut(StockOut stockOut)
        {
            _stockOutDAL.AddStockOut(stockOut);
        }

        public void UpdateStockOut(StockOut stockOut)
        {
            _stockOutDAL.UpdateStockOut(stockOut);
        }

        public void DeleteStockOut(int id)
        {
            _stockOutDAL.DeleteStockOut(id);
        }

        public List<Product> GetAllProducts()
        {
            return _stockOutDAL.GetAllProducts();
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _stockOutDAL.GetAllWarehouses();
        }
    }
}