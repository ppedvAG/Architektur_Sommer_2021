using System;
using System.Collections.Generic;

namespace ppedv.MovieThemeCollector.Contracts
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Movie> AsActor { get; set; } = new HashSet<Movie>();
        public virtual ICollection<Movie> AsDirector { get; set; } = new HashSet<Movie>();
        public virtual Movie Debut { get; set; }
    }

}
