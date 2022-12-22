using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Main.Service
{
	public class UtilisateurService : IUtilisateurService
	{
		private readonly IUtilisateurDAO _utilisateurDAO;

		public UtilisateurService(IUtilisateurDAO utilisateurDAO)
		{
			_utilisateurDAO = utilisateurDAO;
		}

		async Task<ClaimsPrincipal?> IUtilisateurService.Login(string email, string password, bool isPersistent)
		{
			Utilisateur? user = await _utilisateurDAO.GetUtilisateurByEmail(email);

			if (user is null) 
				return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
							new Claim(ClaimTypes.Email, "")
                    }));

			if (user.MotDePasse != password) 
			return new ClaimsPrincipal(
				new ClaimsIdentity(
					new Claim[]
					{
							new Claim(ClaimTypes.Name, "")
                    }));

            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Name, user.Prenom),
						new Claim(ClaimTypes.Email, email),
						new Claim(ClaimTypes.IsPersistent, isPersistent.ToString()),
					}, 
					CookieAuthenticationDefaults.AuthenticationScheme));
		}

        async Task<ICollection<Utilisateur>> IUtilisateurService.GetUtilisateurCollegues(int id)
        {
            ICollection<Utilisateur> collegues = new List<Utilisateur>();
            Utilisateur u = await _utilisateurDAO.GetUtilisateurById(id);
            Dictionary<int, Utilisateur> dicoCollegues = await _utilisateurDAO.GetAllCollegue(u);
                    
            foreach (KeyValuePair<int, Utilisateur> entry in dicoCollegues)
            {
                collegues.Add(entry.Value);
            }

            return collegues;
        }

        async Task<Utilisateur> IUtilisateurService.GetUtilisateur(int? id)
        {
            return await _utilisateurDAO.GetUtilisateurById((int)id);
        }

        async Task IUtilisateurService.RemoveCollegue(Utilisateur utilisateur, Utilisateur collegue)
        {
            await _utilisateurDAO.DeleteCollegue(utilisateur, collegue);
        }

        async Task<bool> IUtilisateurService.AddCollegueToUtilisateur(int utilisateurId, string collegueEmail)
        {
            Utilisateur col = await _utilisateurDAO.GetUtilisateurByEmail(collegueEmail);
            Utilisateur u = await _utilisateurDAO.GetUtilisateurById(utilisateurId);

            if (col is null || u is null)
                return false;

            await _utilisateurDAO.AddCollegue(u, col);

            return true;
        }
	}
}
