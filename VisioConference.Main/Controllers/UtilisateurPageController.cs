using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;
using VisioConference.Models;
using VisioConference.Service;

namespace VisioConference.Main.Controllers
{
    public class UtilisateurPageController : Controller
    {
        private readonly Service.IUtilisateurService _utilisateurServices;
        private readonly ISalonService _salonService;

        public UtilisateurPageController(Service.IUtilisateurService utilisateurService, ISalonService salonService)
        {
            _utilisateurServices = utilisateurService;
            _salonService = salonService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["deconnection"] = "Déconnection";
            ViewData["name"] = User.FindFirst(ClaimTypes.Name).Value;

            dynamic myModel = new ExpandoObject();

            ICollection<Utilisateur> collegues = await _utilisateurServices
                .GetUtilisateurCollegues(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));

            ICollection<Salon> salons = await _salonService
                .GetUserSalons(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));

            myModel.Utilisateur = collegues;
            myModel.Salon = salons;

            return View(myModel);
        }

        public IActionResult AjouterCollegue()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterCollegue([Bind("Email")] Utilisateur collegue)
        {
            bool added = await _utilisateurServices
                .AddCollegueToUtilisateur(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value), collegue.Email);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Suprimer(int? id)
        {
            if(id == null || _utilisateurServices == null)
                return NotFound();

            var collegue = await _utilisateurServices.GetUtilisateur(id);
            if (collegue == null)
                return NotFound();

            return View(collegue);
        }

        [HttpPost, ActionName("Suprimer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmerSup(int id)
        {
            if (_utilisateurServices == null)
                return Problem("Entity set 'UtilisateurService' is null.");

            var utilisateur = await _utilisateurServices.GetUtilisateur(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            var collegue = await _utilisateurServices.GetUtilisateur(id);
            if(utilisateur != null && collegue != null)
            {
                await _utilisateurServices.RemoveCollegue(utilisateur, collegue);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
