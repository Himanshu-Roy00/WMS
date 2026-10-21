using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class UOMDAL
	{
		private readonly AppDbContext _context;

		public UOMDAL(AppDbContext context)
		{
			_context = context;
		}

		public List<UOM> GetAllUOMs()
		{
			return _context.UOMs
				.Where(u => u.IsActive)
				.ToList();
		}

		public UOM GetUOMById(int id)
		{
			return _context.UOMs.Find(id);
		}

		public void AddUOM(UOM uom)
		{
			_context.UOMs.Add(uom);
			_context.SaveChanges();
		}

		public void UpdateUOM(UOM uom)
		{
			var existing = _context.UOMs.Find(uom.UOMId);
			if (existing != null)
			{
				existing.UOMName = uom.UOMName;
				existing.ShortName = uom.ShortName;
				_context.SaveChanges();
			}
		}

		public void DeleteUOM(int id)
		{
			var uom = _context.UOMs.Find(id);
			if (uom != null)
			{
				uom.IsActive = false;
				_context.SaveChanges();
			}
		}
	}
}