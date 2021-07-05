using System.Collections.Generic;

namespace ppedv.MovieThemeCollector.Contracts.Interfaces
{
    public interface IDemoDataService
    {
        IEnumerable<Person> CreateDemoPersons(int amount);
        IEnumerable<Movie> CreateDemoMovies(int amount);
        IEnumerable<Movie> CreateDemoMoviesWithPerson(int amount);
    }
}
