using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisioConference.Main.Data;
using VisioConference.Models;
using VisioConference.Service;

namespace VisioConference.Main.Controllers
{
	public class SalonController : Controller
	{
		private readonly ISalonService _salonService;
		private readonly IMessageService _messageService;
		private readonly IUtilisateurService _utilisateurService;
		private int _salonId;

		public SalonController(ISalonService salonService, IMessageService messageService, IUtilisateurService utilisateurService)
		{
			_salonService = salonService;
			_messageService = messageService;
			_utilisateurService = utilisateurService;
			_salonId = 0;
		}

		public async Task<IActionResult> Index(int salonId)
		{
			_salonId = salonId;
			if (_salonService == null)
				return NotFound();

			var salon = await _salonService.GetSalonById(salonId);
			if (salon == null)
				return NotFound();

			SalonNewMessageMessagesViewModel model = new SalonNewMessageMessagesViewModel()
			{
				Salon = salon,
				NewMessage = new Message(),
				Messages = await _salonService.GetMessagesSalon(salon)
			};

			return View(model);
		}

		public async Task<IActionResult> Invite()
		{
			Microsoft.Extensions.Primitives.StringValues stringValues = Request.Form["SalonId"];

			return RedirectToAction("Index", "Invite", new { SalonId = Convert.ToInt32(stringValues) });
		}

		[HttpPost]
		public async Task<IActionResult> AjouterMessage(SalonNewMessageMessagesViewModel model)
		{
			Utilisateur utilisateur = await _utilisateurService
				.GetUtilisateurById(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));

			Microsoft.Extensions.Primitives.StringValues stringValues = Request.Form["SalonId"];

			model.Salon = await _salonService.GetSalonById(Convert.ToInt32(stringValues));

			await _messageService
				.CreateMessage(model.NewMessage, utilisateur, model.Salon);

			return RedirectToAction("Index", new { salonId = model.Salon.Id });
		}

		public IActionResult Retour()
		{
			return RedirectToAction("Index", "UtilisateurPage");
		}
	}
}
