using System;

namespace Factory_Demo
{
    public class Mittagessen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Maultaschen");
        }
    }
}
