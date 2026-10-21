using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
    public class DashboardBAL
    {
        private readonly DashboardDAL _dashboardDAL;

        public DashboardBAL(DashboardDAL dashboardDAL)
        {
            _dashboardDAL = dashboardDAL;
        }

        public int GetTotalProducts() => _dashboardDAL.GetTotalProducts();
        public int GetTotalWarehouses() => _dashboardDAL.GetTotalWarehouses();
        public int GetTotalStockIn() => _dashboardDAL.GetTotalStockIn();
        public int GetTotalStockOut() => _dashboardDAL.GetTotalStockOut();
        public int GetTotalTransfers() => _dashboardDAL.GetTotalTransfers();
        public List<Product> GetLowStockProducts() => _dashboardDAL.GetLowStockProducts();
        public List<StockIn> GetRecentStockIn() => _dashboardDAL.GetRecentStockIn();
        public List<StockOut> GetRecentStockOut() => _dashboardDAL.GetRecentStockOut();
        public List<ProductStock> GetWarehouseStock() => _dashboardDAL.GetWarehouseStock();
    }
}