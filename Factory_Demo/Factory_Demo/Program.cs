using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Kantine michisKantine = new Kantine();

            IEssen lecker = michisKantine.GibEssen();

            lecker.Beschreibung();

            Console.WriteLine("---ENDE---");
            Console.ReadLine();
        }
    }
}
