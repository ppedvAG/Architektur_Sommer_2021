using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Amazon a = new Amazon(new SMSSystem(), new Rechnungssystem(), new DPDLieferdienst(), new Lagersystem());

            a.Bestellen(33, 12);


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
