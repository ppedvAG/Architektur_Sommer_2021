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
        public ICollection<Person> Actors { get; set; } = new HashSet<Person>();
        public ICollection<Person> Directors { get; set; } = new HashSet<Person>();
        public ICollection<Person> Debutants { get; set; } = new HashSet<Person>();
    }

}
