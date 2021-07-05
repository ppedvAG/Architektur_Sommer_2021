using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System;

namespace ppedv.MovieThemeCollector.Data.EFCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext con = new EfContext();

        public IMovieRepository MovieRepository => new EfMovieRepository(con);

        public void Dispose()
        {
            con.Dispose();
        }

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            if (typeof(T) == typeof(Movie))
                return new EfMovieRepository(con) as IRepository<T>;

            return new EfRepository<T>(con);
        }
        public int Save()
        {
            return con.SaveChanges();
        }

    }
}
