using System;

namespace ppedv.MovieThemeCollector.Contracts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }

        IRepository<T> GetRepo<T>() where T : Entity;

        int Save();
    }
}
