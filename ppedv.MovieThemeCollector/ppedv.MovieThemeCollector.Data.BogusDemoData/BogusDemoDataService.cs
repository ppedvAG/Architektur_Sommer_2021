using Bogus;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System.Collections.Generic;
using Person = ppedv.MovieThemeCollector.Contracts.Person;

namespace ppedv.MovieThemeCollector.Data.BogusDemoData
{
    public class BogusDemoDataService : IDemoDataService
    {
        public string Language { get; set; } = "de";
        public int Seed { get; set; } = 12;

        public IEnumerable<Movie> CreateDemoMovies(int amount)
        {
            Faker<Movie> faker = CreateMovieFaker();

            return faker.Generate(amount);
        }

        public IEnumerable<Movie> CreateDemoMoviesWithPerson(int amount)
        {
            var persons = CreateDemoPersons(100);

            var faker = CreateMovieFaker()
               .RuleFor(x => x.Directors, (f, u) => new HashSet<Person>(f.PickRandom(persons, f.Random.Int(1, 3))))
               .RuleFor(x => x.Actors, (f, u) => new HashSet<Person>(f.PickRandom(persons, f.Random.Int(1, 10))))
               .RuleFor(x => x.Debutants, (f, u) => new HashSet<Person>(f.PickRandom(persons, f.Random.Int(1, 5))));

            return faker.Generate(amount);

        }

        public IEnumerable<Person> CreateDemoPersons(int amount)
        {
            var faker = new Faker<Person>(Language).UseSeed(Seed)
            .RuleFor(x => x.Name, (f, u) => f.Name.FullName())
            .RuleFor(x => x.BirthDate, (f, u) => f.Date.Past(40));

            return faker.Generate(amount);
        }

        private Faker<Movie> CreateMovieFaker()
        {
            return new Faker<Movie>(Language).UseSeed(Seed)
               .RuleFor(x => x.Title, (f, u) => $"{f.Commerce.Color()} {f.Commerce.Product()}")
               .RuleFor(x => x.Published, (f, u) => f.Date.Past(5))
               .RuleFor(x => x.SoundTheme, (f, u) => f.Music.Genre())
               .RuleFor(x => x.Length, (f, u) => f.Random.Int(30, 300));
        }
    }
}
