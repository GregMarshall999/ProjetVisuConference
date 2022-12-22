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
            Salon salonDB = await Dao.GetSalonById(salon.Id);
            if (salonDB.ProprietaireId == utilisateur.Id)
                await Dao.AddUserSalon(salon, utilisateur);
            else throw new Exception("Seul le propriétaire peut ajouter un utilisateur à ce salon");
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

        async Task<bool> ISalonService.IsProprietaireSalon(Utilisateur utilisateur, Salon salon)
        {
            Salon salonDB = await Dao.GetSalonById(salon.Id);

            if(salonDB.ProprietaireId == utilisateur.Id)
                return true;
            else return false;
        }

        async Task<List<Salon>> ISalonService.GetSalonCree(int utilisateurId)
        {
            return null;
        }

        async Task<List<Salon>> ISalonService.GetSalonInvitee(int utilisteurId)
        {
            return null;
        }
    }
}
