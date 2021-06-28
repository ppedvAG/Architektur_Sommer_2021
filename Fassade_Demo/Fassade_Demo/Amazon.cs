using System;

namespace Fassade_Demo
{
    class Amazon
    {
        public Amazon(Emailsystem es, Rechnungssystem rs, IVersanddienst pl, Lagersystem ls)
        {
            this.es = es;
            this.rs = rs;
            this.pl = pl;
            this.ls = ls;
        }

        private Emailsystem es;
        private Rechnungssystem rs;
        private IVersanddienst pl;
        private Lagersystem ls ;

        public void Bestellen(int produktID, int kundenID)
        {
            if (ls.ProduktLagernd(produktID))
            {
                if (rs.HatKundeRechnungenOffen(kundenID) == false)
                {
                    rs.BezahlvorgangStarten(kundenID);
                    pl.PaketversandBeauftragen();
                    ls.ProduktNachbestellen(produktID);
                    if(es is SMSSystem smsSystem) // C# 7
                    {
                        // C# 6 und drunter
                        //((SMSSystem)es).SMSVersenden();
                        //(es as SMSSystem).SMSVersenden();
                        // Seit C# 7
                        smsSystem.SMSVersenden();
                    }
                    else
                        es.BestätigungsmailVersenden();
                }
                else
                {
                    Console.WriteLine("Bezahle zuerst deine Rechnung !!!!!!!!!!!!!!");
                }
            }
            else
            {
                Console.WriteLine("Hamma nicht mehr :/");
            }
        }

    }
}
