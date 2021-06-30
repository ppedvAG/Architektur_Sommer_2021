using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.Data.EFCore
{
    public class EfRepository : IRepository
    {
        EfContext con = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            con.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            con.Remove(entity);
        }

        public void DeleteById<T>(int id) where T : Entity
        {
            var loaded = GetById<T>(id);
            if (loaded != null)
                con.Remove(loaded);
        }

        public T GetById<T>(int id) where T : Entity
        {
            return con.Find<T>(id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return con.Set<T>();
        }

        public int Save()
        {
            return con.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            con.Update(entity);
        }
    }
}
