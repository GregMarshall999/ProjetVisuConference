using System;
using System.Collections.Generic;
using System.Linq;
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
        public UtilisateurService(MyContext context)
        {
            IUtilisateurDAO Dao = new UtilisateurDAO(context);       
        }

        async Task IUtilisateurService.AddCollegue(Utilisateur utilisateur, Utilisateur collegue)
        {
            await Dao.AddCollegue(utilisateur, collegue);
        }

        async Task IUtilisateurService.AddUtilisateur(Utilisateur utilisateur)
        {
            await Dao.AddUtilisateur(utilisateur);
        }

        async Task IUtilisateurService.DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue)
        {
            await Dao.DeleteCollegue(utilisateur, UtilisateurCollegue);
        }

        async Task IUtilisateurService.DeleteUtilisateur(Utilisateur utilisateur)
        {
            await Dao.DeleteUtilisateur(utilisateur);
        }

        Task<Dictionary<int, Utilisateur>> IUtilisateurService.GetAllCollegue(Utilisateur utilisateur)
        {
            return Dao.GetAllCollegue(utilisateur);
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
    }
}
