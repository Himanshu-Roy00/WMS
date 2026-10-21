using Microsoft.AspNetCore.Mvc;
using WMS.BAL;

namespace WMS.Controllers
{
	public class AccountController : Controller
	{
		private readonly AccountBAL _accountBAL;

		public AccountController(AccountBAL accountBAL)
		{
			_accountBAL = accountBAL;
		}

		// GET - Login Page
		public IActionResult Login()
		{
			return View();
		}

		// POST - Login Form Submit
		[HttpPost]
		public IActionResult Login(string email, string password)
		{
			var user = _accountBAL.Login(email, password);

			if (user != null)
			{
				// Session mein save karo
				HttpContext.Session.SetString("UserName", user.Name);
				HttpContext.Session.SetInt32("RoleId", user.RoleId);
				HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("Email", user.Email);

                // Role ke hisaab se Dashboard pe bhejo
                if (user.RoleId == 1)
					return RedirectToAction("AdminDashboard", "Dashboard");
				else if (user.RoleId == 2)
					return RedirectToAction("AdminDashboard", "Staff");
				else if (user.RoleId == 3)
					return RedirectToAction("AdminDashboard", "Manager");
			}

			ViewBag.Error = "Invalid Email or Password!";
			return View();
		}

		// Logout
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}
	}
}




