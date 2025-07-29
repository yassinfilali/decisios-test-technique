using System;
using System.ComponentModel.DataAnnotations;

namespace PersonApi.Models
{
    /// <summary>
    /// Représente une personne
    /// </summary>
    public class Personne
    {
        /// <summary>
        /// Identifiant de la personne (guid)
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Prénom de la personne
        /// </summary>
        [Required]
        public string Prenom { get; set; }

        /// <summary>
        /// Nom de la personne
        /// </summary>
        [Required]
        public string Nom { get; set; }
    }
}
