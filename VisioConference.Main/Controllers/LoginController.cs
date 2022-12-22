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
		private readonly IUtilisateurService _utilisateurService;

		public LoginController(IUtilisateurDAO utilisateurDAO, IUtilisateurService exempleService)
		{
			_utilisateurDAO = utilisateurDAO;
            _utilisateurService = exempleService;
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
			ViewData["MauvaisMotDePasse"] = "";
			ViewData["CompteInnexistant"] = "";

			var user = await _utilisateurService.Login(utilisateur.Email, utilisateur.MotDePasse, utilisateur.IsPersistent);

			if (user is null)
				return View();

			var email = user.FindFirst(ClaimTypes.Email).Value;
			var name = user.FindFirst(ClaimTypes.Name).Value;

			if(email == "")
			{
				ViewData["CompteInnexistant"] = "Cette adresse mail n'est pas associé à un compte Utilisateur.";
				return View(utilisateur);
			}

			if(name == "")
			{
				ViewData["MauvaisMotDePasse"] = "Mot de passe erroné.";
				return View(utilisateur);
			}

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, 
				new AuthenticationProperties { IsPersistent = Convert.ToBoolean(user.FindFirst(ClaimTypes.IsPersistent).Value) });

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Log()
		{
			var user = await _utilisateurService.Login("greg@gmail.com", "123", true);
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
