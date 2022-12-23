using VisioConference.Models;

namespace VisioConference.DAO
{
    public interface IUtilisateurDAO
    {
        Task<List<Utilisateur>> GetAllUtilisateur();

        Task AddUtilisateur(Utilisateur utilisateur);

        Task UpdateUtilisateur(Utilisateur utilisateur);

        Task<Utilisateur> GetUtilisateurById(int Id);

        Task DeleteUtilisateur(Utilisateur utilisateur);

        Task<bool> AddCollegue(Utilisateur utilisateur, Utilisateur collegue);

        Task DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue);

        Task<Dictionary<int, Utilisateur>> GetAllCollegue(Utilisateur utilisateur);

        Task<Utilisateur> GetUtilisateurByEmail(string email);



    }
}
