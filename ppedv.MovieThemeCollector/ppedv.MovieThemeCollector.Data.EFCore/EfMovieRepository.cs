using Microsoft.EntityFrameworkCore;
using ppedv.MovieThemeCollector.Common;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.MovieThemeCollector.Data.EFCore
{
    public class EfMovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public EfMovieRepository(EfContext con) : base(con)
        { }

        public override void Add(Movie entity)
        {
            Logger.Instance.Info("NEUES MOVIE");
            base.Add(entity);
        }

        public IEnumerable<Movie> GetMovieFromThatSpecialStroedProc()
        {
            return con.Movies
                      .FromSqlRaw("EXECUTE dbo.GetMoviesOrderdByYear;")
                      .ToList();
        }
    }
}
