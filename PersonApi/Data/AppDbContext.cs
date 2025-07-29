using Microsoft.EntityFrameworkCore;
using PersonApi.Models;

namespace PersonApi.Data
{
    /// <summary>
    /// Représente la base de données
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// La table personne de la base de donnée 
        /// </summary>
        public DbSet<Personne> Personnes { get; set; }
    }
}
