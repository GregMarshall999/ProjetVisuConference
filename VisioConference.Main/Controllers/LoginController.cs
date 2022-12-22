using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisioConference.Main.Service;
using VisioConference.Models;

namespace VisioConference.Main.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUtilisateurService _utilisateurService;

		public LoginController(IUtilisateurService exempleService)
		{
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

		public async Task<IActionResult> Deconnection()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
	}
}
