using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Main.Service
{
	public class ExempleService : IExempleService
	{
		private readonly IUtilisateurDAO utilisateurDAO;

		public ExempleService()
		{
			
		}

		async Task<ClaimsPrincipal?> IExempleService.Login(string email, string password, bool isPersistent)
		{
			Utilisateur? user = null; //get user from dao with username and password
			if (user is null) return null;

			return new ClaimsPrincipal(
				new ClaimsIdentity(
					new Claim[]
					{
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Name, user.Prenom),
						new Claim(ClaimTypes.Email, email),
						//new Claim(ClaimTypes.Role, user.role), //<- if user has roles
						new Claim(ClaimTypes.IsPersistent, isPersistent.ToString()),
					}, 
					CookieAuthenticationDefaults.AuthenticationScheme));
		}
	}
}
