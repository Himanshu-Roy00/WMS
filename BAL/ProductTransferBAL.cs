using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
    public class ProductTransferBAL
    {
        private readonly ProductTransferDAL _transferDAL;

        public ProductTransferBAL(ProductTransferDAL transferDAL)
        {
            _transferDAL = transferDAL;
        }

        public List<ProductTransfer> GetAllTransfers()
        {
            return _transferDAL.GetAllTransfers();
        }

        public void AddTransfer(ProductTransfer transfer)
        {
            _transferDAL.AddTransfer(transfer);
        }

        public void UpdateTransfer(ProductTransfer transfer)
        {
            _transferDAL.UpdateTransfer(transfer);
        }

        public void DeleteTransfer(int id)
        {
            _transferDAL.DeleteTransfer(id);
        }

        public List<Product> GetAllProducts()
        {
            return _transferDAL.GetAllProducts();
        }

        public void AddDetail(ProductTransferDetail detail)
        {
            _transferDAL.AddDetail(detail);
        }

        public List<ProductTransferDetail> GetDetailsByTransferId(int transferId)
        {
            return _transferDAL.GetDetailsByTransferId(transferId);
        }

        public void DeleteDetail(int detailId)
        {
            _transferDAL.DeleteDetail(detailId);
        }
    }
}