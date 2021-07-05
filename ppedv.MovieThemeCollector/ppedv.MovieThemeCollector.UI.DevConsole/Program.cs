using ppedv.MovieThemeCollector.Common;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Logic;
using System;
using System.Linq;

namespace ppedv.MovieThemeCollector.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Info("Consolen UI gestartet");
            Console.WriteLine("Hello World!");

            var core = new Core(new Device.ACME.ACMESoundplayer2000(), new Data.EFCore.EfUnitOfWork());
            core.Device.Play(300, 200);

            var query = core.UnitOfWork.GetRepo<Movie>().Query().Where(x => !string.IsNullOrWhiteSpace(x.Title));
            //Logger.Instance.Info($"Query: {query.ToQueryString()}");
            foreach (var item in query.ToList())
            {
                Console.WriteLine($"{item.Title}");
                Console.WriteLine($"\tDirectors: {string.Join(", ", item.Directors.Select(x => x.Name))}");
                Console.WriteLine($"\tActors: {string.Join(", ", item.Actors.Select(x => x.Name))}");
                Console.WriteLine($"\tDebutants: {string.Join(", ", item.Debutants.Select(x => x.Name))}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
