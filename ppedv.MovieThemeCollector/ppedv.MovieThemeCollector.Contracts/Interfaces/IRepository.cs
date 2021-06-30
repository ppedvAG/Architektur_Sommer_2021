using System.Linq;

namespace ppedv.MovieThemeCollector.Contracts.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;

        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void DeleteById<T>(int id) where T : Entity;
        void Update<T>(T entity) where T : Entity;


        int Save();
    }
}
