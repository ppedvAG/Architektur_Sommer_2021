using System;

namespace Factory_Demo
{
    public class Frühstück : IEssen
    { 
        public void Beschreibung()
        {
            Console.WriteLine("Eier mit Speck");
        }
    }
}
