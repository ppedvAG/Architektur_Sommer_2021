using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.Logic.Services
{
    public class MoviesService : IMoviesService
    {
        public IUnitOfWork UnitOfWork { get;  }

        public MoviesService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void DeleteMovie(Movie movie)
        {
            UnitOfWork.MovieRepository.Delete(movie);
        }

        public void DeleteMovieWithAllAttachedPersons(Movie movie, IPeopleService ps)
        {
            foreach (var p in movie.Actors)
            {
                p.AsActor.Remove(movie);
            }

            foreach (var p in movie.Directors)
            {
                p.AsDirector.Remove(movie);
            }

            foreach (var p in movie.Directors.Union(movie.Actors))
            {
                ps.DeletePerson(p);
            }

            DeleteMovie(movie);
        }


        public Movie GetLatestMovie()
        {
            return UnitOfWork.GetRepo<Movie>().Query().OrderByDescending(x => x.Published.Date).ThenBy(x => x.Title).FirstOrDefault();
        }
    }
}
