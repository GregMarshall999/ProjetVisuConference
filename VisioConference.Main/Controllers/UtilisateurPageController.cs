using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;
using VisioConference.Main.Data;
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

            int utilisateurId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ColleguesSalonsInvitesViewModel model = new ColleguesSalonsInvitesViewModel();

            ICollection<Utilisateur> collegues = await _utilisateurServices.GetUtilisateurCollegues(utilisateurId);
            ICollection<Salon> salons = await _salonService.GetUserSalons(utilisateurId);
            ICollection<Salon> invitee = await _salonService.GetSalonsInvite(utilisateurId);

            salons = new List<Salon>();
            invitee = new List<Salon>();

            model.Utilisateurs = collegues;
            model.Salons = salons;
            model.Invitee = invitee;

            return View(model);
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

        public IActionResult CreerSalon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreerSalon(Salon salon)
        {
            int utilisateurId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            salon.ProprietaireId = utilisateurId;
            salon.Proprietaire = await _utilisateurServices.GetUtilisateur(utilisateurId);
            await _salonService.CreateSalon(salon);
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
