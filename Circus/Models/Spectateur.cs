
using System;
using Circus.Interfaces;

namespace Circus.Model
{
    /// <summary>
    /// Représente un spectateur
    /// </summary>
    public class Spectateur : Observer
    {
        /// <summary>
        /// Nom du spectateur
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Constructeur qui initialise un spectateur
        /// </summary>
        /// <param name="nom"></param>
        public Spectateur(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Cette méthode permet la réaction à un tour du singe
        /// </summary>
        /// <param name="tour"></param>
        public void Update(Tour tour)
        {
            if (tour.Type == TypeTour.Acrobatique)
                Console.WriteLine($"{Nom} applaudit !");
            else
                Console.WriteLine($"{Nom} siffle !");
        }
    }

}
