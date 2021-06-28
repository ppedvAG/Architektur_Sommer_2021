using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var lecker1 = new Trüffel(new Trüffel( new Salami(new Käse(new Pizza()))));

            Console.WriteLine(lecker1.Beschreibung);
            Console.WriteLine(lecker1.Preis);


            IComponent MichisLieblingspizza = new Pizza();

            for (int i = 0; i < 100; i++)
            {
                MichisLieblingspizza = new Käse(MichisLieblingspizza);
                // Pizza mit 100 Käse
            }

            Console.WriteLine(MichisLieblingspizza.Beschreibung);
            Console.WriteLine(MichisLieblingspizza.Preis);

            // Aspektorientiertem Programmieren

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
