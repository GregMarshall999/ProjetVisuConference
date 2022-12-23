using VisioConference.Models;

namespace VisioConference.Main.Data
{
	public class ColleguesSalonsInvitesViewModel
	{
		public IEnumerable<Utilisateur> Utilisateurs { get; set; }
		public IEnumerable<Salon> Salons { get; set; }
		public IEnumerable<Salon> Invitee { get; set; }
	}
}
