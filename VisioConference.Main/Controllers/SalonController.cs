using Microsoft.AspNetCore.Mvc;
using VisioConference.Main.Data;
using VisioConference.Models;
using VisioConference.Service;

namespace VisioConference.Main.Controllers
{
	public class SalonController : Controller
	{
		private readonly ISalonService _salonService;
		private readonly IMessageService _messageService;

		public SalonController(ISalonService salonService, IMessageService messageService)
		{
			_salonService = salonService;
			_messageService = messageService;
		}

		public async Task<IActionResult> Index(int salonId)
		{
			if (_salonService == null)
				return NotFound();

			var salon = await _salonService.GetSalonById(salonId);
			if (salon == null)
				return NotFound();

			SalonNewMessageMessagesViewModel model = new SalonNewMessageMessagesViewModel()
			{
				Salon = salon,
				NewMessage = new Message(),
				Messages = salon.Messages
			};

			return View(model);
		}

		public async Task<IActionResult> AjouterMessage(SalonNewMessageMessagesViewModel model)
		{
			await _messageService.CreateMessage(model.NewMessage);
			return RedirectToAction("Index", new { salonId = model.Salon.Id });
		}

		public IActionResult Retour()
		{
			return RedirectToAction("Index", "UtilisateurPage");
		}
	}
}
