using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Contenu { get; set; }

        [Required]
        public Utilisateur Utilisateur { get; set; }

        public int UtilisateurId { get; set; }

        public ICollection<Fichier> piècesJointe { get; set; }

        public Fichier Fichier_Id;

        [Required]
        public Salon Salon { get; set; }

        public int SalonId { get; set; }


    }
}
