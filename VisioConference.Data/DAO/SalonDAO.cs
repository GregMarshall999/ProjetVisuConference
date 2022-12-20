using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;

namespace VisioDAO.DAO
{
    internal class SalonDAO : AbstractDAO, ISalonDAO
    {
        public SalonDAO(MyContext context) : base(context)
        {
        }


        // OK
        async Task ISalonDAO.CreateSalon(Salon salon)
        {
            context.Salon.Add(salon);
            await context.SaveChangesAsync();
        }

        async Task<List<Salon>> ISalonDAO.GetAllSalon()
        {
            return await context.Salon.AsNoTracking().ToListAsync();
        }

        async Task<Salon> ISalonDAO.GetSalonById(int id)
        {
            Salon salonDB = await context.Salon.FindAsync(id);
            if (salonDB != null)
                return salonDB;
            else throw new Exception("Salon introuvable");
        }

        async Task ISalonDAO.deleteSalon(int id)
        {
            Salon salon = await context.Salon.FindAsync(id);
            if (salon != null)
            {
                context.Salon.Remove(salon);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Salon introuvable");
        }

        async Task ISalonDAO.addUserSalon(Salon salon, Utilisateur utilisateur)
        {
            Salon salonDB = await context.Salon.FindAsync(salon.Id);
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);

            if (salonDB != null && utilisateurDB != null)
            {
                UtilisateurSalon jointure = new UtilisateurSalon()
                {
                    SalonId = salonDB.Id,
                    UtilisateurId = utilisateurDB.Id,
                };
                context.UtilisateursSalons.Add(jointure);
                await context.SaveChangesAsync();
            }
            else if (salonDB == null)
                throw new Exception("Salon introuvable, Utilisateur non rajouté");
            else throw new Exception("Utilisateur introuvable");
        }

        async Task<List<Utilisateur>> ISalonDAO.GetUtilisateursSalon(Salon salon)
        {
            Salon salonDB = await context.Salon.FindAsync(salon.Id);

            if (salonDB != null)
            {
                var query =
                from u in context.Utilisateur
                join us in context.UtilisateursSalons on u.Id equals us.UtilisateurId
                join s in context.Salon on us.SalonId equals s.Id
                where s.Id == salonDB.Id
                select u;

                return await query.AsNoTracking().ToListAsync();
            }
            else throw new Exception("Salon n'existe pas en base de données");
        }


        async Task ISalonDAO.DeleteUserSalon(Salon salon, Utilisateur utilisateur)
        {
            Salon salonDB = await context.Salon.FindAsync(salon.Id);
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);

            var query =
                from u in context.Utilisateur
                join us in context.UtilisateursSalons on u.Id equals us.UtilisateurId
                join s in context.Salon on us.SalonId equals s.Id
                where s.Id == salonDB.Id
                where u.Id == utilisateurDB.Id
                select us;

            List<UtilisateurSalon> resultQuery = await query.AsNoTracking().ToListAsync();

            resultQuery.ForEach(j => context.UtilisateursSalons.Remove(j));
            await context.SaveChangesAsync();
        }


        async Task<List<Message>> ISalonDAO.GetMessagesSalon(Salon salon)
        {
            Salon salonDB = await context.Salon.FindAsync(salon.Id);

            var query =
                from m in context.Message
                join s in context.Salon
                on m.SalonId equals salon.Id
                where s.Id == salonDB.Id
                select m;

            return await query.AsNoTracking().ToListAsync();
        }      
    }
}
