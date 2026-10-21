using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.DAL
{
	public class AccountDAL
	{
		private readonly AppDbContext _context;

		public AccountDAL(AppDbContext context)
		{
			_context = context;
		}

		public User GetUserByEmailAndPassword(string email, string password)
		{
			return _context.Users
				.Include(u => u.Role)
				.FirstOrDefault(u => u.Email == email
				&& u.Password == password);
		}
	}
}



