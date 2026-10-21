using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
    public class ProductStockBAL
    {
        private readonly ProductStockDAL _stockDAL;

        public ProductStockBAL(ProductStockDAL stockDAL)
        {
            _stockDAL = stockDAL;
        }

        public List<ProductStock> GetAllStocks()
        {
            return _stockDAL.GetAllStocks();
        }

        public ProductStock GetStockById(int id)
        {
            return _stockDAL.GetStockById(id);
        }

        public void AddStock(ProductStock stock)
        {
            _stockDAL.AddStock(stock);
        }

        public void UpdateStock(ProductStock stock)
        {
            _stockDAL.UpdateStock(stock);
        }

        public void DeleteStock(int id)
        {
            _stockDAL.DeleteStock(id);
        }

        public List<Product> GetAllProducts()
        {
            return _stockDAL.GetAllProducts();
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _stockDAL.GetAllWarehouses();
        }
    }
}