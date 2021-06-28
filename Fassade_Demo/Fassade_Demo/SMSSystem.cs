using System;

namespace Fassade_Demo
{
    // Adapter: Vererbung:

    class SMSSystem : Emailsystem
    {
        public void SMSVersenden()
        {
            // Logger evt dranhängen ?
            // BestätigungsmailVersenden();
            // Logik für SMS ausführen....
            Console.WriteLine("Neues SMS-Versenden");
        }

        // Für den Fall das die Logik überschreibbar ist
        public override void BestätigungsmailVersenden()
        {
            // Anstelle der Originallogik
            // base.BestätigungsmailVersenden();

            // Wird die neue Logik ausgeführt
            Console.WriteLine("Überschriebene SMS wird verschickt");
        }
    }
}
