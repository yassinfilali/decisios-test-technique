namespace Circus.Model
{
    /// <summary>
    /// Type de tour possible pour un singe
    /// </summary>
    public enum TypeTour
    {
        Acrobatique,
        Musique
    }

    /// <summary>
    /// Représente un tour exécuté pendant une représentation
    /// </summary>|
    public class Tour
    {
        /// <summary>
        ///  Nom du tour
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Type du tour (accrobatique ou musique)
        /// </summary>
        public TypeTour Type { get; set; }

        /// <summary>
        /// Constructeur qui initialise un nouveau tour 
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="type"></param>
        public Tour(string nom, TypeTour type)
        {
            Nom = nom;
            Type = type;
        }
    }
}
