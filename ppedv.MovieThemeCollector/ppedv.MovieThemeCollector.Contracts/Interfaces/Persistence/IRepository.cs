using System.Linq;

namespace ppedv.MovieThemeCollector.Contracts.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T GetById(int id);

        void Add(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        void Update(T entity);

    }
}
