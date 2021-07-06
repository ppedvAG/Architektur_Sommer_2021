using System.Collections.Generic;

namespace ppedv.MovieThemeCollector.Contracts.Interfaces.Services
{
    public interface IDemoDataService
    {
        IEnumerable<Person> CreateDemoPersons(int amount);
        IEnumerable<Movie> CreateDemoMovies(int amount);
        IEnumerable<Movie> CreateDemoMoviesWithPerson(int amount);
    }
}
