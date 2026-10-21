using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class SupplierBAL
	{
		private readonly SupplierDAL _supplierDAL;

		public SupplierBAL(SupplierDAL supplierDAL)
		{
			_supplierDAL = supplierDAL;
		}

		// Get All
		public List<Supplier> GetAllSuppliers()
		{
			return _supplierDAL.GetAllSuppliers();
		}

		// Add
		public void AddSupplier(Supplier supplier)
		{
			_supplierDAL.AddSupplier(supplier);
		}

		// Update
		public void UpdateSupplier(Supplier supplier)
		{
			_supplierDAL.UpdateSupplier(supplier);
		}

		// Delete
		public void DeleteSupplier(int id)
		{
			_supplierDAL.DeleteSupplier(id);
		}

		// Get By Id
		public Supplier GetSupplierById(int id)
		{
			return _supplierDAL.GetSupplierById(id);
		}
	}
}