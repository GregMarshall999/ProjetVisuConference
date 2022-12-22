using System.Security.Claims;
using VisioConference.Models;

namespace VisioConference.Main.Service
{
    public interface IUtilisateurService
    {
		public Task<ClaimsPrincipal?> Login(string username, string password, bool isPersistent);
        public Task<Dictionary<int, Utilisateur>> GetUtilisateurCollegues(int id);
    }
}
