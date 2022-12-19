using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Contenu { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public ICollection<Fichier> piècesJointe { get; set; }

        public Fichier Fichier_Id;

        public int SalonId { get; set; }

        public Salon Salon { get; set; }

    }
}
