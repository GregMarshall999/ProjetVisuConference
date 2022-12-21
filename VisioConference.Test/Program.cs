// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;
using VisioDAO.DAO;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=ProjetVisuConference;");

MyContext context = new MyContext(optionsBuilder.Options);


IUtilisateurDAO utilisateurDAO = new UtilisateurDAO(context);


Utilisateur u1 = new Utilisateur()
{
    Nom = "Marco",
    Prenom = "Pedro",
    MotDePasse = "azerty",
    DateDeNaissance = DateTime.Now,
    Email = "jeanpedro@gmail.com"
};

Utilisateur u2 = new Utilisateur()
{
    Nom = "Luigi",
    Prenom = "spaghetti",
    MotDePasse = "azerty",
    DateDeNaissance = DateTime.Now,
    Email = "jeanpedro@gmail.com"
};

Utilisateur u3 = new Utilisateur()
{
    Nom = "Louis",
    Prenom = "Charles",
    MotDePasse = "azerty",
    DateDeNaissance = DateTime.Now,
    Email = "jeanpedro@gmail.com"
};

Utilisateur u4 = new Utilisateur()
{
    Nom = "Ahmed",
    Prenom = "Mohamed",
    MotDePasse = "azerty",
    DateDeNaissance = DateTime.Now,
    Email = "jeanpedro@gmail.com"
};

Utilisateur u5 = new Utilisateur()
{
    Nom = "James",
    Prenom = "Lord",
    MotDePasse = "azerty",
    DateDeNaissance = DateTime.Now,
    Email = "jeanpedro@gmail.com"
};

await utilisateurDAO.AddUtilisateur(u1);
await utilisateurDAO.AddUtilisateur(u2);
await utilisateurDAO.AddUtilisateur(u3);
await utilisateurDAO.AddUtilisateur(u4);
await utilisateurDAO.AddUtilisateur(u5);

Utilisateur UtilisateurById = await utilisateurDAO.getUtilisateurById(2);
Console.WriteLine(1);

Console.WriteLine("----------------Update---------------- + GetAllUtilisateur --------------");
UtilisateurById.Nom = "NomModifié";
await utilisateurDAO.UpdateUtilisateur(UtilisateurById);


List<Utilisateur> utilisateurs = new List<Utilisateur>();
utilisateurs = await utilisateurDAO.getAllUtilisateur();

utilisateurs.ForEach(u => Console.WriteLine(u.Nom));

//await utilisateurDAO.DeleteUtilisateur(1);    --> Suppression OK

//Console.WriteLine("-----------------GetAll après suppression Id1 --------------------");

//utilisateurs.ForEach(u => Console.WriteLine(u.Nom));

Console.WriteLine("----------- Ajout collègues + GetAllCOllègue ----------------- ");

Utilisateur UtilisateurById2 = new Utilisateur();
UtilisateurById2 = await utilisateurDAO.getUtilisateurById(21);

Utilisateur UtilisateurById3 = new Utilisateur();
UtilisateurById3 = await utilisateurDAO.getUtilisateurById(22);

Utilisateur UtilisateurById4 = new Utilisateur();
UtilisateurById4 = await utilisateurDAO.getUtilisateurById(23);

Utilisateur UtilisateurById5 = new Utilisateur();
UtilisateurById5 = await utilisateurDAO.getUtilisateurById(24);

await utilisateurDAO.AddCollegue(UtilisateurById3, UtilisateurById);
await utilisateurDAO.AddCollegue(UtilisateurById3, UtilisateurById2);
await utilisateurDAO.AddCollegue(UtilisateurById3, UtilisateurById4);
await utilisateurDAO.AddCollegue(UtilisateurById3, UtilisateurById5);

Dictionary<int, Utilisateur> collègues = new Dictionary<int, Utilisateur>();
collègues = await utilisateurDAO.GetAllCollegue(UtilisateurById3);

foreach (KeyValuePair<int, Utilisateur> collègue in collègues)
{
    Console.WriteLine("Id: {0}, Nom de l'Utilisateur: {1}",
        collègue.Key, collègue.Value.Nom);
}


