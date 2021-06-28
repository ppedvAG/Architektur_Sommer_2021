using System;

namespace Fassade_Demo
{
    class DPDLieferdienst : IVersanddienst
    {
        public void PaketversandBeauftragen()
        {
            Console.WriteLine("Paket wird mit DPD verschickt");
        }
    }
}
