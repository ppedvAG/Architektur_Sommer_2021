using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            swaggerClient sc = new swaggerClient("https://localhost:5001/", new System.Net.Http.HttpClient());
            
            sc.MoviesAllAsync().Result.ToList().ForEach(x => Console.WriteLine(x.Title));

        }
    }
}
