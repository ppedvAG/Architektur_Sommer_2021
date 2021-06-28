using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var Ikea1 = Schrank.BaueSchrank()
                               .MitBöden(2)
                               .MitTüren(4)
                               .MitOberfläche(Oberflächenart.Lackiert)
                               .InFarbe("Gelb")
                               .Konstruiere();
            
            var Ikea2 = Schrank.BaueSchrank()
                               .MitBöden(6)
                               .MitTüren(2)
                               .MitOberfläche(Oberflächenart.Gewachst)
                               .MitKleiderstange(false)
                               .MitMetallschiene(true)
                               .Konstruiere();


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
