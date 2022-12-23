using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Service
{
    public class SalonService : ISalonService
    {
        ISalonDAO _Dao;

        public SalonService(ISalonDAO Dao)
        {
            _Dao = Dao;
        }

        async Task ISalonService.AddUserSalon(Salon salon, Utilisateur utilisateur)
        {
           await _Dao.AddUserSalon(salon, utilisateur);
        }

        async Task ISalonService.CreateSalon(Salon salon)
        {
            await _Dao.CreateSalon(salon);
        }

        async Task ISalonService.DeleteSalon(Salon salon)
        {
            await _Dao.DeleteSalon(salon);
        }

        async Task ISalonService.DeleteUserSalon(Salon salon, Utilisateur utilisateur)
        {
            await _Dao.DeleteUserSalon(salon, utilisateur);
        }

        async Task<List<Salon>> ISalonService.GetAllSalon()
        {
            return await _Dao.GetAllSalon();
        }

        async Task<List<Message>> ISalonService.GetMessagesSalon(Salon salon)
        {
            return await _Dao.GetMessagesSalon(salon);
        }

        async Task<Salon> ISalonService.GetSalonById(int id)
        {
           return await _Dao.GetSalonById(id);
        }

        async Task<List<Utilisateur>> ISalonService.GetUtilisateursSalon(Salon salon)
        {
            return await _Dao.GetUtilisateursSalon(salon);
        }

        // Liste des salons créés
        async Task<List<Salon>> ISalonService.GetUserSalons(int utilisateurId)
        {
            return await _Dao.GetUserSalons(utilisateurId);
        }

        async Task<List<Salon>> ISalonService.GetUserInvites(int utilisateurId)
        {

            return await _Dao.GetSalonInvite(utilisateurId);
        }
    }
}
