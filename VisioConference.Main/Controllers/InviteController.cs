using Microsoft.AspNetCore.Mvc;

namespace VisioConference.Main.Controllers
{
	public class InviteController : Controller
	{
		public IActionResult Index(int salonId)
		{

			return View();
		}
	}
}
