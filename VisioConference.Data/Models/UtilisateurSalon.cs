using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class UtilisateurSalon
    {     
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
