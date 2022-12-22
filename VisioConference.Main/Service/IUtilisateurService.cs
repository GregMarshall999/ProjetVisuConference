using System.Collections;
using System.Security.Claims;
using VisioConference.Models;

namespace VisioConference.Main.Service
{
	public interface IUtilisateurService
	{
		public Task<ClaimsPrincipal?> Login(string username, string password, bool isPersistent);
        public Task<ICollection<Utilisateur>> GetUtilisateurCollegues(int id);
        public Task<Utilisateur> GetUtilisateur(int? id);
        public Task RemoveCollegue(Utilisateur utilisateur, Utilisateur collegue);
        public Task<bool> AddCollegueToUtilisateur(int utilisateurId, string collegueEmail);
	}
}
