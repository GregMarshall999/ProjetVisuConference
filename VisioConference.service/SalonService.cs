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
    public class SalonService : ISalonService
    {
        ISalonDAO Dao;

        public SalonService(MyContext context)
        {
            ISalonDAO Dao = new SalonDAO(context);
        }

        async Task ISalonService.AddUserSalon(Salon salon, Utilisateur utilisateur)
        {
            await Dao.AddUserSalon(salon, utilisateur);
        }

        async Task ISalonService.CreateSalon(Salon salon)
        {
            await Dao.CreateSalon(salon);
        }

        async Task ISalonService.DeleteSalon(Salon salon)
        {
            await Dao.DeleteSalon(salon);
        }

        async Task ISalonService.DeleteUserSalon(Salon salon, Utilisateur utilisateur)
        {
            await Dao.DeleteUserSalon(salon, utilisateur);
        }

        async Task<List<Salon>> ISalonService.GetAllSalon()
        {
            return await Dao.GetAllSalon();
        }

        async Task<List<Message>> ISalonService.GetMessagesSalon(Salon salon)
        {
            return await Dao.GetMessagesSalon(salon);
        }

        async Task<Salon> ISalonService.GetSalonById(int id)
        {
            return await Dao.GetSalonById(id);
        }

        async Task<List<Utilisateur>> ISalonService.GetUtilisateursSalon(Salon salon)
        {
            return await Dao.GetUtilisateursSalon(salon);
        }
    }
}
