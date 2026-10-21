using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Users()
		{
			return View();
		}
	}
}
