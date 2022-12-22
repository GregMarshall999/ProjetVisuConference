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

        async Task<Dictionary<int, Utilisateur>> IUtilisateurService.GetUtilisateurCollegues(int id)
        {
            Utilisateur u = await _utilisateurDAO.GetUtilisateurById(id);
            return await _utilisateurDAO.GetAllCollegue(u);
        }
    }
}
