using System;

namespace Factory_Demo
{
    public class KeinEssen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("*magenknurrgeräusch*");
        }
    }
}
