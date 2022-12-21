using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Main.Models
{
	public static class SeedData
	{
        public static List<Utilisateur> utilisateurs = new List<Utilisateur>
        {
            new Utilisateur()
            {
                Nom = "Marshall",
                Prenom = "Gregory",
                MotDePasse = "123"
            }
        };

		public async static void Initialize(IServiceProvider serviceProvider)
		{
            IUtilisateurDAO utilisateurDAO = serviceProvider.GetRequiredService<IUtilisateurDAO>();
            var users = await utilisateurDAO.getAllUtilisateur();

            if(users.Count != 0)
                return;

            foreach (var u in utilisateurs)
                await utilisateurDAO.AddUtilisateur(u);
		}
	}
}
