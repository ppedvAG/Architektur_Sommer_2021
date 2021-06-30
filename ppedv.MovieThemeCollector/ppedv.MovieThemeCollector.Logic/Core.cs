using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System.Linq;

namespace ppedv.MovieThemeCollector.Logic
{
    public class Core
    {
        public IDevice Device { get; }
        public IRepository Repo { get; }

        public Core(IDevice device, IRepository repo)
        {
            Device = device;
            Repo = repo;
        }

        public Movie GetLatestMovie()
        {
            return Repo.Query<Movie>().OrderByDescending(x => x.Published.Date).ThenBy(x => x.Title).FirstOrDefault();
        }
    }
}
