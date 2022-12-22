using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        IUtilisateurDAO _Dao;
        public UtilisateurService(IUtilisateurDAO Dao)
        {
            _Dao = Dao;
        }

        async Task IUtilisateurService.AddCollegue(Utilisateur utilisateur, Utilisateur collegue)
        {
            await _Dao.AddCollegue(utilisateur, collegue);
        }

        async Task IUtilisateurService.AddUtilisateur(Utilisateur utilisateur)
        {
            await _Dao.AddUtilisateur(utilisateur);
        }

        async Task IUtilisateurService.DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue)
        {
            await _Dao.DeleteCollegue(utilisateur, UtilisateurCollegue);
        }

        async Task IUtilisateurService.DeleteUtilisateur(Utilisateur utilisateur)
        {
            await _Dao.DeleteUtilisateur(utilisateur);
        }

        Task<Dictionary<int, Utilisateur>> IUtilisateurService.GetAllCollegue(Utilisateur utilisateur)
        {
            return _Dao.GetAllCollegue(utilisateur);
        }

        Task<List<Utilisateur>> IUtilisateurService.GetAllUtilisateur()
        {
            return _Dao.GetAllUtilisateur();
        }

        async Task<Utilisateur> IUtilisateurService.GetUtilisateurByEmail(string email)
        {
            return await _Dao.GetUtilisateurByEmail(email);
        }

        async Task<Utilisateur> IUtilisateurService.GetUtilisateurById(int Id)
        {
            return await _Dao.GetUtilisateurById(Id);
        }

        async Task IUtilisateurService.UpdateUtilisateur(Utilisateur utilisateur)
        {
            await _Dao.UpdateUtilisateur(utilisateur);
        }
    }
}
