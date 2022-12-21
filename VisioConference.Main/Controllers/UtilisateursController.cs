using Microsoft.AspNetCore.Mvc;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;
using VisioDAO.DAO;

namespace VisioConference.Main.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly IUtilisateurDAO _utilisateurDAO;

        public UtilisateursController(MyContext context)
        {
            _utilisateurDAO = new UtilisateurDAO(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUtilisateur()
        {
            return View();
        }

        public async Task<IActionResult> CreateUtilisateur([Bind("Id,Nom,Prenom,MotDePasse,DateDeNaissance,Email,SalonsCrees,UtilisateursSalons,Utilisateurs,Collegues")] Utilisateur utilisateur)
        {
            if(ModelState.IsValid)
            {
                await _utilisateurDAO.AddUtilisateur(utilisateur);
                return RedirectToAction(nameof(Index));
            }

            return View(utilisateur);
        }
    }
}
