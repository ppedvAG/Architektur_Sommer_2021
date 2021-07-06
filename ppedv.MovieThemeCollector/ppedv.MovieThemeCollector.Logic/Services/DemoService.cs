using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Contracts.Interfaces.Services;

namespace ppedv.MovieThemeCollector.Logic.Services
{
    public class DemoService 
    {
        public IUnitOfWork UnitOfWork { get; }
        public IDemoDataService DemoDataService { get; }

        public DemoService(IUnitOfWork unitOfWork, IDemoDataService demoDataService)
        {
            UnitOfWork = unitOfWork;
            DemoDataService = demoDataService;
        }

        public void CreateDemoDataAndStoreInDatabase()
        {
            var demoMovies = DemoDataService.CreateDemoMoviesWithPerson(10);
            foreach (var dm in demoMovies)
            {
                UnitOfWork.MovieRepository.Add(dm);
            }
            UnitOfWork.Save();
        }
    }
}
