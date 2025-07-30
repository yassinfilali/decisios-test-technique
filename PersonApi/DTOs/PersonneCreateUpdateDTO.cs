namespace PersonApi.DTOs
{
    /// <summary>
    /// data pour création / la mise à jour d'une personne
    /// </summary>
    public class PersonneCreateUpdateDTO
    {
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
