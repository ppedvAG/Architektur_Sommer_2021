using ppedv.MovieThemeCollector.Contracts.Interfaces;

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

    }
}
