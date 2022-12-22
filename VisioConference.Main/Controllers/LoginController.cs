using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisioConference.DAO;
using VisioConference.Main.Service;
using VisioConference.Models;

namespace VisioConference.Main.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUtilisateurDAO _utilisateurDAO;
		private readonly IUtilisateurService _exempleService;

		public LoginController(IUtilisateurDAO utilisateurDAO, IUtilisateurService exempleService)
		{
			_utilisateurDAO = utilisateurDAO;
			_exempleService = exempleService;
		}

		//Get : Login
		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
				return RedirectToAction("Index", "Home");

			return View();
		}

		//Get : Login/Connection
		public IActionResult Connection()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Connection([Bind("Email,MotDePasse,IsPersistent")] Utilisateur utilisateur)
		{
			//use dao get user by email

			ViewData["MauvaisMotDePasse"] = "";
			ViewData["CompteInnexistant"] = "";

			var users = await _utilisateurDAO.GetAllUtilisateur();
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

		public async Task<IActionResult> Log()
		{
			var user = await _exempleService.Login("greg@gmail.com", "123", true);
			if (user == null) return View();

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, 
				new AuthenticationProperties { IsPersistent = Convert.ToBoolean(user.FindFirst(ClaimTypes.IsPersistent).Value) });

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
	}
}
