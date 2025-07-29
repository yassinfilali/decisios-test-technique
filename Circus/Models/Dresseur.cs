
using System;
using System.Collections.Generic;
using Circus.Interfaces;

namespace Circus.Model
{
    /// <summary>
    /// Représente un dresseur
    /// </summary>
    public class Dresseur
    {
        /// <summary>
        /// Nom du dresseur 
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Constructeur qui initilise un dresseur
        /// </summary>
        /// <param name="nom"></param>
        public Dresseur(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Cette méthode permet de faire executer un tour à un singe
        /// </summary>
        /// <param name="singe"></param>
        /// <param name="tour"></param>
        public void DonnerOrdre(Singe singe, Tour tour)
        {
            Console.WriteLine($"{Nom} demande au singe de faire le tour : {tour.Nom}");
            singe.FaireUnTour(tour);
        }
    }

}
