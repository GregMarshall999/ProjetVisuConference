using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public bool IsPersistent { get; set; } = false;

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime DateDeNaissance { get; set; }

        [Required]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage ="Email non valide")]
        public string Email { get; set; }

        public virtual ICollection<Salon> SalonsCrees { get; set; }

        public virtual ICollection<UtilisateurSalon> UtilisateursSalons { get; set; }


        [InverseProperty("Collegues")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
        public virtual ICollection<Utilisateur> Collegues { get; set; }
    }
}
