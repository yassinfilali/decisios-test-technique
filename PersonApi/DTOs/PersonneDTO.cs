namespace PersonApi.DTOs
{
    /// <summary>
    /// Représente une personne
    /// </summary>
    public class PersonneDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public required string Prenom { get; set; }

        /// <summary>
        /// Nom de famille
        /// </summary>
        public required string Nom { get; set; }
    }
}
