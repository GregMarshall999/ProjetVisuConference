using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Models;

namespace VisioConference.Main.Service
{
    public interface IUtilisateurService
    {
		public Task<ClaimsPrincipal?> Login(string username, string password, bool isPersistent);
    }
}
