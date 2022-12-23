using VisioConference.Models;

namespace VisioConference.Main.Data
{
	public class UtilisateurSalonViewModel
	{
		public IEnumerable<Utilisateur> Utilisateurs { get; set; }
		public IEnumerable<Salon> Salons { get; set; }
	}
}
