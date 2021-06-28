using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < 20; i++)
            {
                //var logger = new Logger();
                Task.Run(() => Logger.Instance.Log("Test #1"));
                Task.Run(() => Logger.Instance.Log("Test #2"));
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
