using System;

namespace Fassade_Demo
{
    class Emailsystem
    {
        public virtual void BestätigungsmailVersenden() // Macht die Logik überschreibbar
        {
            Console.WriteLine("Bestätigungsmail mit Rechnung wurde versendet");
        }
    }
}
