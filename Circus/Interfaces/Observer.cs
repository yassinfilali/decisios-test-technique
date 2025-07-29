
using Circus.Model;

namespace Circus.Interfaces
{
    /// <summary>
    /// Interface observer
    /// </summary>
    public interface Observer
    {
        /// <summary>
        /// Cette méthode sera appelée lors d'un tour lancé
        /// </summary>
        /// <param name="tour"></param>
        void Update(Tour tour);
    }
}
