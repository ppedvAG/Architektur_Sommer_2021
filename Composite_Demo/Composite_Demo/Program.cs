using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Praxis

            Einzelaufgabe e1 = new Einzelaufgabe { Beschreibung = "Demo 1", IstErledigt = false };
            Einzelaufgabe e2 = new Einzelaufgabe { Beschreibung = "Demo 2", IstErledigt = false };
            Einzelaufgabe e3 = new Einzelaufgabe { Beschreibung = "Demo 3", IstErledigt = true };
            Einzelaufgabe e4 = new Einzelaufgabe { Beschreibung = "Demo 4", IstErledigt = false };
            Einzelaufgabe e5 = new Einzelaufgabe { Beschreibung = "Demo 5", IstErledigt = false };

            Aufgabenliste a1 = new Aufgabenliste();
            a1.AufgabeHinzufügen(e1);
            a1.AufgabeHinzufügen(e2);


            Aufgabenliste a2 = new Aufgabenliste();
            a2.AufgabeHinzufügen(e3);
            a2.AufgabeHinzufügen(e4);


            Aufgabenliste a3 = new Aufgabenliste();
            a3.AufgabeHinzufügen(e5);
            a3.AufgabeHinzufügen(a2);
            a3.AufgabeHinzufügen(a1);

            Console.WriteLine(a3.IstErledigt);
            a3.AufgabeErledigen();
            Console.WriteLine(a3.IstErledigt);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
