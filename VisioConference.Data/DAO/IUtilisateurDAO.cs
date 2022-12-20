using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Models;

namespace VisioConference.DAO
{
    internal interface IUtilisateurDAO
    {
        Task<List<Utilisateur>> getAllUtilisateur();

        Task AddUtilisateur(Utilisateur utilisateur);

        Task UpdateUtilisateur(Utilisateur utilisateur);

        Task<Utilisateur> getUtilisateurById(int Id);

        Task DeleteUtilisateur(int Id);

        Task AddCollegue(Utilisateur utilisateur, Utilisateur collegue);

        Task DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue);

        Task<Dictionary<int, Utilisateur>> GetAllCollegue(Utilisateur utilisateur);
    }
}
