using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Models
{
    public class Fichier
    {
        public int Id { get; set; }

        public string FNom { get; set; }


        public byte[] FData { get; set; }

        public string getType(Fichier fichier)
        {
            return Path.GetExtension(fichier.FNom);
        }
    }
}
