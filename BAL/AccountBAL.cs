using WMS.DAL;
using WMS.Models;

namespace WMS.BAL
{
	public class AccountBAL
	{
		private readonly AccountDAL _accountDAL;

		public AccountBAL(AccountDAL accountDAL)
		{
			_accountDAL = accountDAL;
		}

		public User Login(string email, string password)
		{
			return _accountDAL.GetUserByEmailAndPassword(email, password);
		}
	}
}


