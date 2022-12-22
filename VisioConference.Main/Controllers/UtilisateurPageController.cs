using Microsoft.AspNetCore.Mvc;
using VisioConference.Main.Service;

namespace VisioConference.Main.Controllers
{
    public class UtilisateurPageController : Controller
    {
        private readonly IUtilisateurService _utilisateurServices;

        public UtilisateurPageController(IUtilisateurService utilisateurService)
        {
            _utilisateurServices = utilisateurService;
        }

        public IActionResult Index()
        {
            ViewData["deconnection"] = "Déconnection";
            return View();
        }
    }
}
