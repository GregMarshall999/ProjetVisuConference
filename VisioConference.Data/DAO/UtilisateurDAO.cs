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
    public class UtilisateurDAO : AbstractDAO, IUtilisateurDAO
    {
        public UtilisateurDAO(MyContext context) : base(context)
        {
        }

        // Méthode pour hascher MDP avant de le mettre en BDD
        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algortithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algortithm.ComputeHash(bytes);
            }          
            return Convert.ToBase64String(hashBytes);
        }


        async Task IUtilisateurDAO.AddUtilisateur(Utilisateur utilisateur)
        {
            // utilisateur.MotDePasse = Hash(utilisateur.MotDePasse);
            context.Utilisateur.Add(utilisateur);
            await context.SaveChangesAsync();
        }

        async Task IUtilisateurDAO.DeleteUtilisateur(Utilisateur utilisateur)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);

            if (utilisateurDB != null)
            {
                context.Utilisateur.Remove(utilisateur);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task<List<Utilisateur>> IUtilisateurDAO.GetAllUtilisateur()
        {
            return await context.Utilisateur.AsNoTracking().ToListAsync();
        }

        async Task<Utilisateur> IUtilisateurDAO.GetUtilisateurById(int Id)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(Id);
            if (utilisateurDB != null)
                return utilisateurDB;
            else throw new Exception("utilisateur introuvable");
        }

        async Task IUtilisateurDAO.UpdateUtilisateur(Utilisateur utilisateur)
        {
            //Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);

            if (utilisateur != null)
            {
                context.Entry(utilisateur).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task<bool> IUtilisateurDAO.AddCollegue(Utilisateur utilisateur, Utilisateur collegue)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);
            Utilisateur collegueDB = await context.Utilisateur.FindAsync(collegue.Id);
            var CollegueUtilisateur = await context.Utilisateur
                        .Include(u => u.Collegues)
                        .Where(u => u.Id == utilisateur.Id)
                        .FirstOrDefaultAsync();
            int i = 0;

            if (utilisateurDB != null)
            {
                if (collegueDB != null)
                {
                    if (utilisateurDB.Collegues == null)
                        utilisateurDB.Collegues = new List<Utilisateur>();

                    foreach (var item in CollegueUtilisateur.Collegues)
                    {
                        if (item == CollegueUtilisateur)
                            i = 1;
                    }

                    if (i == 0)
                    {
                        utilisateurDB.Collegues.Add(collegueDB);

                        context.Entry(utilisateurDB).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        async Task IUtilisateurDAO.DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue)
        {
            Utilisateur utilisateurDB = await context.Utilisateur.FindAsync(utilisateur.Id);
            Utilisateur collegueDB = await context.Utilisateur.FindAsync(UtilisateurCollegue.Id);
            var CollegueUtilisateur = await context.Utilisateur
                        .Include(u => u.Collegues)
                        .Where(u => u.Id == utilisateur.Id)
                        .FirstOrDefaultAsync();
            int i = 0;

            if (utilisateurDB != null)
            {
                if (collegueDB != null)
                {
                    if (utilisateurDB.Collegues == null)
                        utilisateurDB.Collegues = new List<Utilisateur>();

                    foreach (var item in CollegueUtilisateur.Collegues)
                    {
                        if (item == CollegueUtilisateur)
                            i = 1;
                    }

                    if (i == 0)
                    {
                        utilisateurDB.Collegues.Remove(collegueDB);
                        context.Entry(utilisateurDB).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                    }
                }
                else throw new Exception("Collègue introuvable");
            }
            else throw new Exception("Utilisateur introuvable");
        }

        async Task<Dictionary<int, Utilisateur>> IUtilisateurDAO.GetAllCollegue(Utilisateur utilisateur)
        {
            var CollegueUtilisateur = await context.Utilisateur
                .Include(u => u.Collegues)
                .Where(u => u.Id == utilisateur.Id)
                .FirstOrDefaultAsync();

            if (CollegueUtilisateur != null)
            {
                Dictionary<int, Utilisateur> collegues = new Dictionary<int, Utilisateur>();

                if (CollegueUtilisateur.Collegues == null)
                    return collegues;

                foreach (var item in CollegueUtilisateur.Collegues)
                {
                    collegues.Add(item.Id, item);
                }
                return collegues;
            }
            else throw new Exception("Utilisateur introuvable");
        }

        Task<Utilisateur> IUtilisateurDAO.GetUtilisateurByEmail(string email)
        {
            var query = 
                from u in context.Utilisateur where u.Email == email
                select u;

                return query.FirstOrDefaultAsync();
        }
    }
}

