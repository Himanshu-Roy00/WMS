using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
