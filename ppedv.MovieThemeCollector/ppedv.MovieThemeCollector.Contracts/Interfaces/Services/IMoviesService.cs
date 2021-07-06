namespace ppedv.MovieThemeCollector.Contracts.Interfaces.Services
{
    public interface IMoviesService
    {
        void DeleteMovie(Movie movie);

        void DeleteMovieWithAllAttachedPersons(Movie movie, IPeopleService ps);
    }
}
