using Microsoft.AspNetCore.Mvc;

namespace VisioConference.Main.Controllers
{
    public class HelloWorldViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["NewMessage"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
