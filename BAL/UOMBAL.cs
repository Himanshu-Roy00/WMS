using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class UOMBAL
	{
		private readonly UOMDAL _uomDAL;

		public UOMBAL(UOMDAL uomDAL)
		{
			_uomDAL = uomDAL;
		}

		public List<UOM> GetAllUOMs()
		{
			return _uomDAL.GetAllUOMs();
		}

		public UOM GetUOMById(int id)
		{
			return _uomDAL.GetUOMById(id);
		}

		public void AddUOM(UOM uom)
		{
			_uomDAL.AddUOM(uom);
		}

		public void UpdateUOM(UOM uom)
		{
			_uomDAL.UpdateUOM(uom);
		}

		public void DeleteUOM(int id)
		{
			_uomDAL.DeleteUOM(id);
		}
	}
}