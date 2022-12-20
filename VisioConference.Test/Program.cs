// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;
using VisioDAO.DAO;

Console.WriteLine("Hello, World!");

//DbContextOptionsBuilder<MyContext> options = new DbContextOptionsBuilder<MyContext> ();
//options.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=ProjetVisuConference;integrated security=True;MultipleActiveResultSets=True;");

var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=ProjetVisuConference;");

MyContext context = new MyContext(optionsBuilder.Options);


IUtilisateurDAO utilisateurDAO = new UtilisateurDAO(context);
    

Utilisateur u1 = new Utilisateur()
    {
        Nom = "Jean",
        Prenom = "Pedro",
        MotDePasse = "azerty",
        DateDeNaissance = DateTime.Now,
        Email = "jeanpedro@gmail.com"
    };

await utilisateurDAO.AddUtilisateur(u1);


Console.WriteLine(utilisateurDAO);


//Task listeUtilisateurs = new Task(() => utilisateurDAO.getAllUtilisateur());
//listeUtilisateurs.Wait();


//listeUtilisateurs.Start();
//listeUtilisateurs.Result.ForEach(u => Console.WriteLine(u.Nom));

