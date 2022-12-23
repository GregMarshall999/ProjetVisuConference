using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;
using VisioDAO.DAO;

namespace VisioConference.Service
{
    public class UtilisateurService : IUtilisateurService
    {

        IUtilisateurDAO Dao;

        string CookieAuthentification;

        public UtilisateurService(MyContext context, string cookieAuthentification)
        {
            IUtilisateurDAO Dao = new UtilisateurDAO(context);
            this.CookieAuthentification = cookieAuthentification;
        }

        async Task<ClaimsPrincipal> IUtilisateurService.Login(string email, string password, bool isPersistent)
        {
            Utilisateur? user = await Dao.GetUtilisateurByEmail(email); //get user from dao with username and password

            if (user is null) return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email,"")
                    }));

            // Password entré n'est pas le même qu'en BDD => return Name ""
            if (user.MotDePasse == password) return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,"")
                    }));

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
                    CookieAuthentification));
        }


        async Task<bool> IUtilisateurService.AddCollegue(int utilisateurId, string collegueEmail)
        {
            Utilisateur utilisateurDB = await Dao.GetUtilisateurById(utilisateurId);
            Utilisateur collegueDB = await Dao.GetUtilisateurByEmail(collegueEmail);

            return await Dao.AddCollegue(utilisateurDB, collegueDB);
        }

        async Task IUtilisateurService.AddUtilisateur(Utilisateur utilisateur)
        {


            await Dao.AddUtilisateur(utilisateur);
        }

        async Task IUtilisateurService.DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue)
        {
            await Dao.DeleteCollegue(utilisateur, UtilisateurCollegue);
        }

        async Task IUtilisateurService.DeleteUtilisateur(int IdUtilisateur)
        {
            Utilisateur UtilisateurDB = await Dao.GetUtilisateurById(IdUtilisateur);
            await Dao.DeleteUtilisateur(UtilisateurDB);
        }

        async Task<Dictionary<int, Utilisateur>> IUtilisateurService.GetAllCollegue(int IdUtilisateur)
        {
            Utilisateur UtilisateurDB = await Dao.GetUtilisateurById(IdUtilisateur);
            return await Dao.GetAllCollegue(UtilisateurDB);
        }

        Task<List<Utilisateur>> IUtilisateurService.GetAllUtilisateur()
        {
            return Dao.GetAllUtilisateur();
        }

        async Task<Utilisateur> IUtilisateurService.GetUtilisateurByEmail(string email)
        {
            return await Dao.GetUtilisateurByEmail(email);
        }

        async Task<Utilisateur> IUtilisateurService.GetUtilisateurById(int Id)
        {
            return await Dao.GetUtilisateurById(Id);
        }

        async Task IUtilisateurService.UpdateUtilisateur(Utilisateur utilisateur)
        {
            await Dao.UpdateUtilisateur(utilisateur);
        }

        async Task<List<Utilisateur>> IUtilisateurService.GetListCollegue(int IdUtilisateur)
        {
            Utilisateur utilisateurDB = await Dao.GetUtilisateurById(IdUtilisateur);

            Dictionary<int, Utilisateur> dictionnaireCollegue = new Dictionary<int, Utilisateur>(await Dao.GetAllCollegue(utilisateurDB));

            List<Utilisateur> collegue = new List<Utilisateur>(dictionnaireCollegue.Values);

            return collegue;
        }
    }
}
