using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Contracts.Interfaces.Services;
using ppedv.MovieThemeCollector.Logic.Services;
using System.Linq;

namespace ppedv.MovieThemeCollector.Logic
{

    /// <summary>
    /// Der Core ist eigentlich nun unnötig, weil die Services einzel genutzt werden können.
    /// Hier ist eine hohe kohesion
    /// </summary>
    public class Core
    {
        public IDevice Device { get; }
        public IUnitOfWork UnitOfWork { get; }

        public DemoService DemoDataService { get; }
        public IPeopleService PeopleService { get; }
        public IMoviesService MoviesService { get; }
        public IMovieThemePlayerService MovieThemePlayerService { get; }


        public Core(IDevice device, IUnitOfWork uow, IDemoDataService demoDataService = null)
        {
            Device = device;
            UnitOfWork = uow;

            DemoDataService = new DemoService(uow, demoDataService);
            PeopleService = new PeopleService(uow);
            MoviesService = new MoviesService(uow);
            MovieThemePlayerService = new MovieThemePlayerService(device);
        }

        public Movie GetLatestMovie()
        {
            return UnitOfWork.GetRepo<Movie>().Query().OrderByDescending(x => x.Published.Date).ThenBy(x => x.Title).FirstOrDefault();
        }
    }
}
