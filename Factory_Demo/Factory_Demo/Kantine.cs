using System;

namespace Factory_Demo
{
    public class Kantine
    {
        public IEssen GibEssen()
        {
            var stunde = DateTime.Now.Hour;

            if (stunde >= 6 && stunde < 11)
                return new Frühstück();
            else if (stunde >= 11 && stunde < 16)
                return new Mittagessen();
            else if (stunde >= 16 && stunde < 22)
                return new Abendessen();
            else
                return new KeinEssen();
        }
    }
}
