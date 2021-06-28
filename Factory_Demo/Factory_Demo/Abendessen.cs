using System;

namespace Factory_Demo
{
    public class Abendessen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Flammkuchen");
        }
    }
}
