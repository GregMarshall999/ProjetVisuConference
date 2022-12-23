using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class Salon
    {
        public Salon()
        {
            this.Messages = new HashSet<Message>();
        }
        public int Id { get; set; }

        public string Nom { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        [Required]
        public Utilisateur Proprietaire { get; set; }

        public int ProprietaireId { get; set; }

        public virtual ICollection<UtilisateurSalon> UtilisateursSalons { get; set; }

        //public static implicit operator Salon(StringValues v)
        //{
            //throw new NotImplementedException();
        //}
    }
}
