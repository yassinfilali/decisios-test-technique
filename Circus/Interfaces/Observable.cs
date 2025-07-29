
using Circus.Model;

namespace Circus.Interfaces
{
    /// <summary>
    /// Interface observable 
    /// </summary>
    public interface Observable
    {
        /// <summary>
        /// Cette méthode permettra d'ajouter un observateur à liste 
        /// </summary>
        /// <param name="observer"> Obervateur à ajouter</param>
        void Ajouter(Observer observer);

        /// <summary>
        /// Cette methode permettra de notifier tous les observateurs
        /// </summary>
        /// <param name="tour">Le tour quui est lancé est communiquer aux observateur</param>
        void Notifier(Tour tour);
    }
}
