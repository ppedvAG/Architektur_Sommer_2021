using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.UI.ASP_WebAPI.Model
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public DateTime PubDate { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        public PersonDTO[] Actors { get; set; }
    }

    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
