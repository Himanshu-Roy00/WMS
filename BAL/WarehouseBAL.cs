using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class WarehouseBAL
	{
		private readonly WarehouseDAL _warehouseDAL;

		public WarehouseBAL(WarehouseDAL warehouseDAL)
		{
			_warehouseDAL = warehouseDAL;
		}

		// Get All
		public List<Warehouse> GetAllWarehouses()
		{
			return _warehouseDAL.GetAllWarehouses();
		}

		// Add
		public void AddWarehouse(Warehouse warehouse)
		{
			_warehouseDAL.AddWarehouse(warehouse);
		}

		// Update
		public void UpdateWarehouse(Warehouse warehouse)
		{
			_warehouseDAL.UpdateWarehouse(warehouse);
		}

		// Delete
		public void DeleteWarehouse(int id)
		{
			_warehouseDAL.DeleteWarehouse(id);
		}

		// Get By Id
		public Warehouse GetWarehouseById(int id)
		{
			return _warehouseDAL.GetWarehouseById(id);
		}
	}
}