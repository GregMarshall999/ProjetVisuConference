using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class Fichier
    {
        public int Id { get; set; }

        [Required]
        public string FNom { get; set; }

        [Required]
        public byte[] FData { get; set; }

        public string getType(Fichier fichier)
        {
            return Path.GetExtension(fichier.FNom);
        }
    }
}
