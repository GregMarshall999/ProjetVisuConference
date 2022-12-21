using Microsoft.AspNetCore.Mvc;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Main.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUtilisateurDAO _utilisateurDAO;

		public LoginController(IUtilisateurDAO utilisateurDAO)
		{
			_utilisateurDAO = utilisateurDAO;
		}

		//Get : Login
		public IActionResult Index()
		{
			return View();
		}

		//Get : Login/Connection
		public IActionResult Connection()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Connection([Bind("Email,MotDePasse")] Utilisateur utilisateur)
		{
			//use dao get user by email

			ViewData["MauvaisMotDePasse"] = "";
			ViewData["CompteInnexistant"] = "";

			var users = await _utilisateurDAO.getAllUtilisateur();
			Utilisateur? found = null;

			users.ForEach(u =>
			{
				if (u.Email == utilisateur.Email)
					found = u;
			});

			if(found != null)
			{
				if(found.MotDePasse == utilisateur.MotDePasse)
					return RedirectToAction(nameof(Connected), found);
				ViewData["MauvaisMotDePasse"] = "Mot de passe erroné.";
				return View(found);
			}

			ViewData["CompteInnexistant"] = "Cette adresse mail n'est pas associé à un compte Utilisateur.";
			return View(found);
		}

		public IActionResult Connected(Utilisateur utilisateur)
		{
			ViewData["Prenom"] = utilisateur.Prenom;
			return View();
		}
	}
}
