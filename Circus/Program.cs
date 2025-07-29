
using Circus.Model;

class Program
{
    static void Main()
    {
        var acro = new Tour("Triple saut", TypeTour.Acrobatique);
        var music = new Tour("Tambourin", TypeTour.Musique);

        var singeCarlos = new Singe();
        var singeBob = new Singe();

        var yassin = new Spectateur("Yassin");

        singeCarlos.Ajouter(yassin);
        singeBob.Ajouter(yassin);

        var carlos = new Dresseur("Carlos");
        var bob = new Dresseur("Bob");

        Console.WriteLine($"{yassin.Nom} se baladais lorsqu'il croisa {carlos.Nom} et {bob.Nom} , qui sont deux dresseur de singe.");

        carlos.DonnerOrdre(singeCarlos, acro);
        bob.DonnerOrdre(singeBob, music);

    }
}

