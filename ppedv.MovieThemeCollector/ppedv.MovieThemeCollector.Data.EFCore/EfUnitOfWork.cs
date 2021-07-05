using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System;

namespace ppedv.MovieThemeCollector.Data.EFCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext con = new EfContext();

        public void Dispose()
        {
            con.Dispose();
        }

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(con);
        }
        public int Save()
        {
            return con.SaveChanges();
        }

    }
}
