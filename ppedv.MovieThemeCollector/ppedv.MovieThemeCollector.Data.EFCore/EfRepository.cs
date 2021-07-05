using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System.Linq;

namespace ppedv.MovieThemeCollector.Data.EFCore
{

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected EfContext con;

        public EfRepository(EfContext con)
        {
            this.con = con;
        }

        public void Add(T entity)
        {
            con.Add(entity);
        }

        public void Delete(T entity)
        {
            con.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var loaded = GetById(id);
            if (loaded != null)
                con.Remove(loaded);
        }

        public T GetById(int id)
        {
            return con.Find<T>(id);
        }

        public IQueryable<T> Query()
        {
            return con.Set<T>();
        }

        public void Update(T entity)
        {
            con.Update(entity);
        }
    }
}
