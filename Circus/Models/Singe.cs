
using System;
using Circus.Interfaces;

namespace Circus.Model
{
    /// <summary>
    /// Représente un singe
    /// </summary>
    public class Singe : Observable
    {
        private List<Observer> observers = new List<Observer>();

        /// <summary>
        /// Ajoute un observateur à la liste des observateur
        /// </summary>
        /// <param name="o"></param>
        public void Ajouter(Observer o)
        {
            observers.Add(o);
        }

        /// <summary>
        /// Notifie les observateurs de la liste des observateur
        /// </summary>
        /// <param name="tour"></param>
        public void Notifier(Tour tour)
        {
            foreach (var observer in observers)
            {
                observer.Update(tour);
            }
        }

        /// <summary>
        /// Cette méthode permet au singe d'exécuter un tour 
        /// </summary>
        /// <param name="tour"></param>
        public void FaireUnTour(Tour tour)
        {
            Console.WriteLine($"Le singe fait le tour : {tour.Nom}");
            Notifier(tour);
        }
    }

}
