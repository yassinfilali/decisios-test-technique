using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.Models;

namespace PersonApi.Services
{
    /// <summary>
    /// Service qui gère les opérations CRUD liées aux entités Personne.
    /// </summary>
    public class PersonneService
    {
        private AppDbContext _context;

        /// <summary>
        /// Constructeur du service
        /// </summary>
        /// <param name="context"></param>
        public PersonneService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère toutes les personnes avec des filtres optionnels sur le nom et le prénom.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns></returns>
        public List<Personne> GetAll(string? nom, string? prenom)
        /// Je me suis appuyé sur des recherches en ligne pour construire cette méthode notamment l'ia.
        /// Même si j’ai utilisé des ressources pour comprendre cette écriture, j’ai pris le temps de bien l’assimiler, et je comprends que :
        /// - AsQueryable() ptransforme une liste de données qu’on peut filtrer étape par étape
        /// - Les conditions avec Contains permettent de faire une recherche partielle
        /// - La méthode retourne ensuite le résultat final avec ToList()
        {
            var personnes = _context.Personnes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nom))
            {
                personnes = personnes.Where(p => p.Nom.ToLower().Contains(nom.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(prenom))
            {
                personnes = personnes.Where(p => p.Prenom.ToLower().Contains(prenom.ToLower()));
            }

            return personnes.ToList();
        }

        /// <summary>
        /// Récupère une personne à partir de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Personne? GetById(Guid id)
        {
            foreach (var personne in _context.Personnes)
            {
                if (personne.Id == id)
                {
                    return personne;
                }
            }

            return null;
        }

        /// <summary>
        /// Cette méthode permet la création d'une nouvelle personne
        /// </summary>
        /// <param name="personne"></param>
        /// <returns></returns>
        public Personne Create(Personne personne)
        {
            personne.Id = Guid.NewGuid();
            _context.Personnes.Add(personne);
            _context.SaveChanges();
            return personne;
        }

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d’une personne existante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updated"></param>
        public void Update(Guid id, Personne updated)
        {
            var existing = _context.Personnes.Find(id);
            if (existing != null)
            {
                existing.Nom = updated.Nom;
                existing.Prenom = updated.Prenom;
                _context.SaveChanges();
            }

        }

        /// <summary>
        /// Cette méthode permet de supprimer une personne
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            var personne = _context.Personnes.Find(id);
            if (personne != null)
            {
                _context.Personnes.Remove(personne);
                _context.SaveChanges();
            }
        }
    }
}
