using Xunit;
using PersonApi.Data;
using PersonApi.Models;
using PersonApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PersonApi.Tests.Services
{
    /// <summary>
    /// Tests unitaires pour le service PersonneService
    /// CRUD
    /// </summary>
    public class PersonneServiceTests
    {
        /// <summary>
        /// Crée une base de données en mémoire pour isoler les tests
        /// </summary>
        private AppDbContext MyDataBase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        /// <summary>
        /// Ce test a pour objectif de verifier que GetAll retourne bien 2 personnes 
        /// et les bonnes personnes (nom et prénom)
        /// </summary>
        [Fact]
        public void GetAll_TestRetournePersonne()
        {
            var db = MyDataBase();
            db.Personnes.AddRange(new List<Personne>
            {
                new Personne { Nom = "Harouchi", Prenom = "Nora" },
                new Personne { Nom = "Bajart", Prenom = "Amandine" }
            });
            db.SaveChanges();

            var service = new PersonneService(db);

            var resultat = service.GetAll(null, null);

            Assert.Equal(2, resultat.Count);

            Assert.Contains(resultat, p => p.Nom == "Harouchi" && p.Prenom == "Nora");
            Assert.Contains(resultat, p => p.Nom == "Bajart" && p.Prenom == "Amandine");
        }

        /// <summary>
        /// Ce test a pour objectif de verifier que Create ajoute une nouvelle personne 
        /// dans la base de donnée
        /// </summary>
        [Fact]
        public void Create_AjoutNouvellePersonne()
        {
            var db = MyDataBase();

            var service = new PersonneService(db);

            var yassin = new Personne
            {
                Nom = "FILALI",
                Prenom = "Yassin"
            };


            var resultat = service.Create(yassin);

            Assert.Equal("Yassin", resultat.Prenom);
            Assert.Equal("FILALI", resultat.Nom);
            Assert.Single(db.Personnes.ToList()); // permet de verifier qu'il n'y a bien qu'un seul element dans la db
        }

        /// <summary>
        /// Ce test a pour objectif de vérifier que GetAll applique correctement les filtres
        /// </summary>
        [Fact]
        public void GetAll_Filtre()
        {
            var db = MyDataBase();

            db.Personnes.AddRange(new List<Personne>
            {
                new Personne { Nom = "FILALI", Prenom = "Yassin" },
                new Personne { Nom = "FIDOULI", Prenom = "Yassin" },
                new Personne { Nom = "BAJART", Prenom = "Amandine" }
            });
            db.SaveChanges();

            var service = new PersonneService(db);


            var resultat = service.GetAll("fi", "Yassin");

            Assert.Equal(2, resultat.Count);
            Assert.All(resultat, p => Assert.Contains("Yassin", p.Prenom));
        }

        /// <summary>
        /// Ce test a pour objectif de vérifier que GetById retourne bien une personne
        /// et la bonne personne
        /// </summary>
        [Fact]
        public void GetById_BonnePersonne()
        {

            var db = MyDataBase();

            var personne = new Personne { Nom = "Filali", Prenom = "Yassin" };
            db.Personnes.Add(personne);
            db.SaveChanges();

            var service = new PersonneService(db);

            var resultat = service.GetById(personne.Id);

            Assert.NotNull(resultat);
            Assert.Equal("Yassin", resultat.Prenom);
            Assert.Equal("Filali", resultat.Nom);
        }

        /// <summary>
        /// Ce test a pour objectif de vérifier que GetById retourne bien null si l'id n'existe pas en db
        /// </summary>
        [Fact]
        public void GetById_NullPersonne()
        {
            var service = new PersonneService(MyDataBase());

            var inexistantId = Guid.NewGuid();
            var resultat = service.GetById(inexistantId);

            Assert.Null(resultat);
        }

        /// <summary>
        /// Ce test a pour objectif de vérifier que Update modifie correctement 
        /// les données d'une personne existante
        /// </summary>
        [Fact]
        public void Update_ModifieUnePersonneDeLaDb()
        {
            var db = MyDataBase();
            var old = new Personne { Nom = "FILILI", Prenom = "Yassin" };
            db.Personnes.Add(old);
            db.SaveChanges();

            var service = new PersonneService(db);
            var updated = new Personne { Nom = "FILALI", Prenom = "Yassin" };


            service.Update(old.Id, updated);

            var resultat = db.Personnes.Find(old.Id);
            Assert.Equal("FILALI", resultat?.Nom);
            Assert.Equal("Yassin", resultat?.Prenom);
        }

        /// <summary>
        /// Ce test a pour objectif de vérifier que Delete supprime 
        /// bien une personne de la db
        /// </summary>
        [Fact]
        public void Delete_UnePersonneDeLaDb()
        {
            var db = MyDataBase();
            var personne = new Personne { Nom = "FILALI", Prenom = "Yassin" };
            db.Personnes.Add(personne);
            db .SaveChanges();

            var service = new PersonneService(db);

            service.Delete(personne.Id);

            var result = db.Personnes.Find(personne.Id);
            Assert.Null(result);
        }
    }
}
