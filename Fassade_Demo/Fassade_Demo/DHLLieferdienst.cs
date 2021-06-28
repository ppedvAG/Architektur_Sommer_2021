using System;
using System.Threading;

namespace Fassade_Demo
{
    class DHLLieferdienst : IVersanddienst
    {
        public void PaketversandBeauftragen()
        {
            Console.WriteLine("Paket wird mit DHL verschickt");
            Thread.Sleep(3000);
        }
    }
}
