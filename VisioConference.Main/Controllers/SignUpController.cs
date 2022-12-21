using Microsoft.AspNetCore.Mvc;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Main.Controllers
{
	public class SignUpController : Controller
	{
		private readonly IUtilisateurDAO _utilisateurDAO;

		public SignUpController(IUtilisateurDAO utilisateurDAO)
		{
			_utilisateurDAO = utilisateurDAO;
		}

		//Get : SignUp
		public IActionResult Index()
		{
			return View();
		}

		//Get : SignUp/CreateAccount
		public IActionResult CreateAccount()
		{
			return View();
		}

		//Post : SignUp/CreateAccount
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateAccount([Bind("Id,Nom,Prenom,MotDePasse,DateDeNaissance,Email")] Utilisateur utilisateur)
		{
			await _utilisateurDAO.AddUtilisateur(utilisateur);
			return RedirectToAction(nameof(Index));
		}
	}
}
