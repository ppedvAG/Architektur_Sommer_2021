using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Composite_Demo
{

    public class Einzelaufgabe : Aufgabe
    {
        public override string Beschreibung { get; set; }

        public override bool IstErledigt { get; set; }

        public override void AufgabeErledigen()
        {
            Thread.Sleep(2000);
            IstErledigt = true;
        }
    }

    public class Aufgabenliste : Aufgabe
    {
        public List<Aufgabe> Unteraufgaben = new List<Aufgabe>();

        public override string Beschreibung { get; set; }
        public override bool IstErledigt
        {
            get
            {
                // Wenn alle Unteraufgaben erledigt sind -> true, ansonsten false
                // Trick: LINQ:
                return Unteraufgaben.All(x => x.IstErledigt == true);
            }
            set
            {
                // Wenn die Value "true" ist, dann aufgabeerledigen ausführen
                // wenn die Value "false" ist, dann alle auf false setzen
                if (value == true)
                    AufgabeErledigen();
                else
                    foreach (var item in Unteraufgaben)
                    {
                        item.IstErledigt = false;
                    }
            }
        }
        public override void AufgabeErledigen()
        {
            foreach (var item in Unteraufgaben)
            {
                item.AufgabeErledigen();
            }
        }

        public void AufgabeHinzufügen(Aufgabe aufgabe)
        {
            Unteraufgaben.Add(aufgabe);
        }
    }

}
