using System;
using System.Threading;

namespace Fassade_Demo
{
    class Rechnungssystem
    {
        public bool HatKundeRechnungenOffen(int kundenID)
        {
            // Wenn der Kunde Rechnungen offen hat -> Bestellvorgang abbrechen
            Console.WriteLine($"Bestellvorgang für Kunde '{kundenID}' wurde authorisiert");
            return false;
        }

        public void BezahlvorgangStarten(int KundenID)
        {
            Console.WriteLine("Bezahlvorgang wird gestartet...");
            Thread.Sleep(4000);
            Console.WriteLine("Bezahlvorgang erfolgreich beendet...");
        }
    }
}
