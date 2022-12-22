using System.Security.Claims;

namespace VisioConference.Main.Service
{
	public interface IExempleService
	{
		public Task<ClaimsPrincipal?> Login(string username, string password, bool isPersistent);
	}
}
