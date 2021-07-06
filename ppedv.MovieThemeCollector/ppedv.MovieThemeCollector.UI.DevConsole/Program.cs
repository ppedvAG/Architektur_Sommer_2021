using Autofac;
using ppedv.MovieThemeCollector.Common;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Contracts.Interfaces.Services;
using ppedv.MovieThemeCollector.Logic;
using ppedv.MovieThemeCollector.Logic.Services;
using System;
using System.Linq;
using System.Reflection;

namespace ppedv.MovieThemeCollector.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Info("Consolen UI gestartet");
            Console.WriteLine("Hello World!");

#if DEBUG
            var deviceLibPath = @$"C:\Users\Fred\source\repos\ppedvAG\Architektur_Sommer_2021\ppedv.MovieThemeCollector\ppedv.MovieThemeCollector.Device.ACME\bin\Debug\net5.0\ppedv.MovieThemeCollector.Device.ACME.dll";
            var dataLibPath = $@"C:\Users\Fred\source\repos\ppedvAG\Architektur_Sommer_2021\ppedv.MovieThemeCollector\ppedv.MovieThemeCollector.Data.EFCore\bin\Debug\net5.0\ppedv.MovieThemeCollector.Data.EFCore.dll";
            var demoLibPath = $@"C:\Users\Fred\source\repos\ppedvAG\Architektur_Sommer_2021\ppedv.MovieThemeCollector\ppedv.MovieThemeCollector.Data.BogusDemoData\bin\Debug\net5.0\ppedv.MovieThemeCollector.Data.BogusDemoData.dll";
#else
            var deviceLibPath= @$"C:\Users\Fred\source\repos\ppedvAG\Architektur_Sommer_2021\ppedv.MovieThemeCollector\ppedv.MovieThemeCollector.Device.ACME\bin\Release\net5.0\ppedv.MovieThemeCollector.Device.ACME.dll";
            var dataLibPath = $@"C:\Users\Fred\source\repos\ppedvAG\Architektur_Sommer_2021\ppedv.MovieThemeCollector\ppedv.MovieThemeCollector.Data.EFCore\bin\Release\net5.0\ppedv.MovieThemeCollector.Data.EFCore.dll";
            var demoLibPath = $@"C:\Users\Fred\source\repos\ppedvAG\Architektur_Sommer_2021\ppedv.MovieThemeCollector\ppedv.MovieThemeCollector.Data.BogusDemoData\bin\Release\net5.0\ppedv.MovieThemeCollector.Data.BogusDemoData.dll";
#endif

            Console.WriteLine(deviceLibPath);

            var deviceAss = Assembly.LoadFrom(deviceLibPath);
            Type typeWithIDevice = deviceAss.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IDevice)));
            IDevice device = (IDevice)Activator.CreateInstance(typeWithIDevice);

            var dataAss = Assembly.LoadFrom(dataLibPath);
            var demoAss = Assembly.LoadFrom(demoLibPath);
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyTypes(dataAss).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAss).Where(t => t.Name.EndsWith("UnitOfWork")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(demoAss).Where(t => t.Name.EndsWith("BogusDemoDataService")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(deviceAss).Where(t => t.Name.EndsWith("ACMESoundplayer2000")).AsImplementedInterfaces();
            builder.RegisterType<PeopleService>().AsImplementedInterfaces();
            
            //builder.RegisterType<Data.EFCore.EfUnitOfWork>().As<IUnitOfWork>();
            //builder.RegisterType(typeof(Data.EFCore.EfMovieRepository)).As(typeof(IMovieRepository));
            var container = builder.Build();
            

            var moviesService = new MoviesService(container.Resolve<IUnitOfWork>());
            //var core = new Core(device,null);
            //var core = new Core(new Device.ACME.ACMESoundplayer2000(), new Data.EFCore.EfUnitOfWork());

            Console.WriteLine($"Sollen Demodaten generiert werden? [j/n]");
            if(Console.ReadKey().Key == ConsoleKey.J)
            {
                var demoService =new DemoService(container.Resolve<IUnitOfWork>(),container.Resolve<IDemoDataService>());
                demoService.CreateDemoDataAndStoreInDatabase();
            }

            var player = new MovieThemePlayerService(container.Resolve<IDevice>());
            player.PlayerDevice.Play(300, 200);

            //delete movie und personen
            var killme = moviesService.UnitOfWork.MovieRepository.Query().OrderByDescending(x => x.Id).FirstOrDefault();
            if(killme !=null)
            {
                moviesService.DeleteMovieWithAllAttachedPersons(killme, container.Resolve<IPeopleService>());
            }

            
            var query = moviesService.UnitOfWork.GetRepo<Movie>().Query().Where(x => !string.IsNullOrWhiteSpace(x.Title));
            //Logger.Instance.Info($"Query: {query.ToQueryString()}");
            foreach (var item in query.ToList())
            {
                Console.WriteLine($"{item.Title}");
                Console.WriteLine($"\tDirectors: {string.Join(", ", item.Directors.Select(x => x.Name))}");
                Console.WriteLine($"\tActors: {string.Join(", ", item.Actors.Select(x => x.Name))}");
                Console.WriteLine($"\tDebutants: {string.Join(", ", item.Debutants.Select(x => x.Name))}");
            }

            moviesService.UnitOfWork.GetRepo<Movie>().Add(new Movie() { Title = "" }); //im log sehen wir die überschriebene Add implementierung
            moviesService.UnitOfWork.MovieRepository.Add(new Movie() { Title = "" }); //im log sehen wir die überschriebene Add implementierung

            //Stored Proc erstellen
            //CREATE PROCEDURE dbo.GetMoviesOrderdByYear
            //AS
            //SELECT* FROM Movies ORDER BY DATEPART(Year, Published)
            try
            {
                foreach (var item in moviesService.UnitOfWork.MovieRepository.GetMovieFromThatSpecialStroedProc())
                {
                    Console.WriteLine($"STORED-PROC: {item.Title}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Stored Proc konnte nicht aufgerufen werden: {ex.Message}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
