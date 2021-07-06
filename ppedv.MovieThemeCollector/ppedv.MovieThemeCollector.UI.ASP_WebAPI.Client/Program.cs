using System;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.UI.ASP_WebAPI.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            swaggerClient sc = new swaggerClient("https://localhost:5001", new System.Net.Http.HttpClient());
            foreach (var item in sc.MoviesAllAsync().Result.ToList())
            {
                Console.WriteLine(item.Title);
            }

            Console.ReadLine();
        }

    }
}
