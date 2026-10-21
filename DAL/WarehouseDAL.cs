using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class WarehouseDAL
	{
		private readonly AppDbContext _context;

		public WarehouseDAL(AppDbContext context)
		{
			_context = context;
		}

		// Get All
		public List<Warehouse> GetAllWarehouses()
		{
			return _context.Warehouses.ToList();
		}

		// Add
		public void AddWarehouse(Warehouse warehouse)
		{
			_context.Warehouses.Add(warehouse);
			_context.SaveChanges();
		}

		// Update
		public void UpdateWarehouse(Warehouse warehouse)
		{
			_context.Warehouses.Update(warehouse);
			_context.SaveChanges();
		}

		// Delete
		public void DeleteWarehouse(int id)
		{
			var warehouse = _context.Warehouses.Find(id);

			if (warehouse != null)
			{
				_context.Warehouses.Remove(warehouse);
				_context.SaveChanges();
			}
		}

		// Get By Id
		public Warehouse GetWarehouseById(int id)
		{
			return _context.Warehouses.Find(id);
		}
	}
}