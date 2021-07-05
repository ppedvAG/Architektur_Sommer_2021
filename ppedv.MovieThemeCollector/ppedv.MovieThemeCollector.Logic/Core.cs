using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System.Linq;

namespace ppedv.MovieThemeCollector.Logic
{
    public class Core
    {
        public IDevice Device { get; }
        public IUnitOfWork UnitOfWork { get; }

        public Core(IDevice device, IUnitOfWork uow)
        {
            Device = device;
            UnitOfWork = uow;
        }

        public Movie GetLatestMovie()
        {
            return UnitOfWork.GetRepo<Movie>().Query().OrderByDescending(x => x.Published.Date).ThenBy(x => x.Title).FirstOrDefault();
        }
    }
}
