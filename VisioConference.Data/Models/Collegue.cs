using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisioConference.Models
{
    public class Collegue
    {
        public int id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int CollegueId { get; set; }
        public Utilisateur collegue { get; set; }
    }
}
