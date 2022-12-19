using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Utilisateur
    {
        public Utilisateur()
        {
            this.ColleguesUtilisateur = new HashSet<Collegue>();
            this.SalonsCrees = new HashSet<Salon>();
        }

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
        public virtual ICollection<Collegue> ColleguesUtilisateur { get; set; }
    }
}
