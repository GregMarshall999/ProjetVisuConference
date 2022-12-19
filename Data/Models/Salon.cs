using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Salon
    {
        public Salon()
        {
            this.Messages = new HashSet<Message>();
        }
        public int Id { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public Utilisateur Proprietaire { get; set; }

        public int ProprietaireId { get; set; }
    }
}
