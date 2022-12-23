using VisioConference.Models;

namespace VisioConference.Main.Data
{
    public class SalonUtilisateurViewModel
    {
        public Salon salon { get; set; }
        public ICollection<Utilisateur> collegues { get; set; }
    }
}
