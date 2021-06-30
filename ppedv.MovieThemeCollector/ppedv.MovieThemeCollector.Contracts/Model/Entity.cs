using System;

namespace ppedv.MovieThemeCollector.Contracts
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Modified { get; set; }
    }
}
