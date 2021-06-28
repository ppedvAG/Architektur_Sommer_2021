using System;

namespace Fassade_Demo
{
    class DeutschePostLieferdienst : IVersanddienst
    {
        public void PaketversandBeauftragen()
        {
            Console.WriteLine("Paket wird mit der deutschen Post verschickt");
        }
    }
}
