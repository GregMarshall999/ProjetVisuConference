using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;

namespace VisioDAO.DAO
{
    internal class UtilisateurDAO : AbstractDAO, IUtilisateurDAO
    {
        public UtilisateurDAO(MyContext context) : base(context)
        {
        }

        async Task IUtilisateurDAO.AddUtilisateur(Utilisateur utilisateur)
        {
            context.Utilisateur.Add(utilisateur);
            await context.SaveChangesAsync();
        }

        async Task IUtilisateurDAO.DeleteUtilisateur(int Id)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(Id);

            if (utilisateurDB != null)
            {
                context.Utilisateur.Remove(utilisateurDB);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task<List<Utilisateur>> IUtilisateurDAO.getAllUtilisateur()
        {
            return await context.Utilisateur.AsNoTracking().ToListAsync();
        }

        async Task<Utilisateur> IUtilisateurDAO.getUtilisateurById(int Id)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(Id);
            if (utilisateurDB != null)
                return utilisateurDB;
            else throw new Exception("utilisateur introuvable");
        }

        async Task IUtilisateurDAO.UpdateUtilisateur(Utilisateur utilisateur)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);

            if (utilisateurDB != null)
            {
                context.Entry(utilisateurDB).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task IUtilisateurDAO.AddCollegue(Utilisateur utilisateur, Utilisateur collegue)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);
            Utilisateur collegueDB = await context.Utilisateur.FindAsync(collegue.Id);

            if (utilisateurDB != null)
            {
                if (collegueDB != null)
                {
                   utilisateurDB.Collegues.Add(collegue);

                    context.Entry(utilisateurDB).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                else throw new Exception("Collègue introuvable");
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task IUtilisateurDAO.DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);
            Utilisateur collegueDB = await context.Utilisateur.FindAsync(UtilisateurCollegue.Id);

            if (utilisateurDB != null)
            {
                if (collegueDB != null)
                {
                    utilisateurDB.Collegues.Remove(collegueDB);

                    context.Entry(utilisateurDB).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                else throw new Exception("Collègue introuvable");
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task<Dictionary<int, Utilisateur>> IUtilisateurDAO.GetAllCollegue(Utilisateur utilisateur)
        {         
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);

            if (utilisateurDB != null)
            {
                Dictionary<int, Utilisateur> collegues = new Dictionary<int, Utilisateur>();

                foreach (var item in utilisateurDB.Collegues)
                {
                    collegues.Add(item.Id, item);
                } 
                return collegues;
            }
            else throw new Exception("Utilisateur introuvable");               
        }
    }
}

