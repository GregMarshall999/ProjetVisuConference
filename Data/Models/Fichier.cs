using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Fichier
    {
        public int ID { get; set; }

        public string FNom { get; set; }


        public byte[] FData { get; set; }

        public string getType(Fichier fichier)
        {
            return Path.GetExtension(fichier.FNom);
        }
    }
}
