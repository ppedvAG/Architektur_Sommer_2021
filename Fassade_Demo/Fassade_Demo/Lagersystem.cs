using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Lagersystem
    {
        public bool ProduktLagernd(int produktID)
        {
            // wenn lagernd -> true
            Console.WriteLine($"Produkt mit der ID '{produktID}' ist lagernd");

            return true; 
        }

        public void ProduktNachbestellen(int produktID)
        {
            // if(produktMitID.Amount < 10)
            // IRL nachbestellen um das Lager aufzufüllen;

            if(produktID % 2 == 0)
                Console.WriteLine($"Produkt mit der ID '{produktID}' wird nachbestellt");
            else
                Console.WriteLine($"Produkt mit der ID '{produktID}' wird NICHT nachbestellt");
        }
    }
}
