using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisioConference.Main.Models;

namespace VisioConference.Main.Controllers
{
    [Authorize] //all controller needs login
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize] //action only
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                ViewData["connection"] = "";
                ViewData["creation"] = "";
                ViewData["deconnection"] = "Déconnection";
                return RedirectToAction("Index", "UtilisateurPage");
            }
            else
            {
                ViewData["connection"] = "Connection";
                ViewData["creation"] = "Créer un compte";
                ViewData["deconnection"] = "";
            }

            return View();
        }

        [Authorize(Roles = "Admin")] //role only here
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}