using System;
using System.Collections.Generic;

namespace ppedv.MovieThemeCollector.Contracts
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public string SoundTheme { get; set; }
        public int Length { get; set; }
        public virtual ICollection<Person> Actors { get; set; } = new HashSet<Person>();
        public virtual ICollection<Person> Directors { get; set; } = new HashSet<Person>();
        public virtual ICollection<Person> Debutants { get; set; } = new HashSet<Person>();
    }

}
