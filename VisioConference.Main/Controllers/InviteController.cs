using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisioConference.Main.Service;
using VisioConference.Models;
using VisioConference.Service;

namespace VisioConference.Main.Controllers
{
	public class InviteController : Controller
	{
		private readonly Service.IUtilisateurService _utilisateurService;
		private readonly ISalonService _salonService;

		public InviteController(Service.IUtilisateurService utilisateurService, ISalonService salonService)
		{
			_utilisateurService = utilisateurService;
			_salonService = salonService;
		}

		public async Task<IActionResult> Index(int salonId)
		{
			ICollection<Utilisateur> utilisateurs = await _utilisateurService.GetUtilisateurCollegues(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
			return View(utilisateurs);
		}

		public async Task<IActionResult> Invite(int? id)
		{
			Utilisateur collegue = await _utilisateurService.GetUtilisateur(id);

			Microsoft.Extensions.Primitives.StringValues stringValues = Request.Form["SalonId"];

			Salon salon = await _salonService.GetSalonById(Convert.ToInt32(stringValues));

			_salonService.AddUserSalon(salon, collegue);
			return View();
		}
	}
}
