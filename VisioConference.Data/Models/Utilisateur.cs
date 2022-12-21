using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class Utilisateur
    {

        public enum TypeUtilisateur
        {
            ADMIN,
            MEMBRE
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string MotDePasse { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Salon> SalonsCrees { get; set; }
        public virtual ICollection<UtilisateurSalon> UtilisateursSalons { get; set; }


        [InverseProperty("Collegues")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
        public virtual ICollection<Utilisateur> Collegues { get; set; }
    }
}
