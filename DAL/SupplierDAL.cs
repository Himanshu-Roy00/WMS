using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class SupplierDAL
	{
		private readonly AppDbContext _context;

		public SupplierDAL(AppDbContext context)
		{
			_context = context;
		}

		// Get All
		public List<Supplier> GetAllSuppliers()
		{
			return _context.Suppliers.ToList();
		}

		// Add
		public void AddSupplier(Supplier supplier)
		{
			_context.Suppliers.Add(supplier);
			_context.SaveChanges();
		}

		// Update
		public void UpdateSupplier(Supplier supplier)
		{
			_context.Suppliers.Update(supplier);
			_context.SaveChanges();
		}

		// Delete
		public void DeleteSupplier(int id)
		{
			var supplier = _context.Suppliers.Find(id);

			if (supplier != null)
			{
				_context.Suppliers.Remove(supplier);
				_context.SaveChanges();
			}
		}

		// Get By Id
		public Supplier GetSupplierById(int id)
		{
			return _context.Suppliers.Find(id);
		}
	}
}