using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WMS.BAL;
using WMS.Models;

namespace WMS.Controllers
{
    public class ProductTransferController : Controller
    {
        private readonly ProductTransferBAL _transferBAL;

        public ProductTransferController(ProductTransferBAL transferBAL)
        {
            _transferBAL = transferBAL;
        }

        public IActionResult ProductTransfer()
        {
            var transfers = _transferBAL.GetAllTransfers();
            return View(transfers);
        }

        [HttpPost]
        public IActionResult Add(ProductTransfer transfer)
        {
            _transferBAL.AddTransfer(transfer);
            return RedirectToAction("ProductTransfer");
        }

        [HttpPost]
        public IActionResult Edit(ProductTransfer transfer)
        {
            _transferBAL.UpdateTransfer(transfer);
            return RedirectToAction("ProductTransfer");
        }

        public IActionResult Delete(int id)
        {
            _transferBAL.DeleteTransfer(id);
            return RedirectToAction("ProductTransfer");
        }

        public IActionResult Detail(int id)
        {
            // Agar id 0 hai to pehla transfer lo
            if (id == 0)
            {
                var firstTransfer = _transferBAL.GetAllTransfers().FirstOrDefault();
                if (firstTransfer != null)
                    id = firstTransfer.ProductTransferId;
            }

            var details = _transferBAL.GetDetailsByTransferId(id);
            ViewBag.TransferId = id;
            ViewBag.ProductList = _transferBAL.GetAllProducts()
                .Select(p => new SelectListItem
                {
                    Value = p.ProductId.ToString(),
                    Text = p.ProductName
                }).ToList();

            return View(details);
        }

        [HttpPost]
        public IActionResult AddDetail(ProductTransferDetail detail)
        {
            _transferBAL.AddDetail(detail);
            return RedirectToAction("Detail",
                new { id = detail.ProductTransferId });
        }

        public IActionResult DeleteDetail(int detailId, int transferId)
        {
            _transferBAL.DeleteDetail(detailId);
            return RedirectToAction("Detail", new { id = transferId });
        }
    }
}