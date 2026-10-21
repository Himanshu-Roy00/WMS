using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
    public class ReportBAL
    {
        private readonly ReportDAL _reportDAL;

        public ReportBAL(ReportDAL reportDAL)
        {
            _reportDAL = reportDAL;
        }

        public List<ProductStock> GetStockReport()
        {
            return _reportDAL.GetStockReport();
        }

        public List<StockIn> GetStockInReport()
        {
            return _reportDAL.GetStockInReport();
        }

        public List<StockOut> GetStockOutReport()
        {
            return _reportDAL.GetStockOutReport();
        }

        public List<ProductTransfer> GetTransferReport()
        {
            return _reportDAL.GetTransferReport();
        }
    }
}