using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using NUnit.Framework;
using ppedv.MovieThemeCollector.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ppedv.MovieThemeCollector.Data.EFCore.Tests
{
    [TestFixture]
    public class EfContextTests
    {
        [Test]
        [Category("Integrationtests")]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            Assert.That(con.Database.EnsureCreated());
        }

        [Test]
        [Category("Integrationtests")]
        public void Can_CREATE_READ_Movie()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            var movie = fix.Build<Movie>().Create();

            using (var con = new EfContext())
            {
                con.Add(movie);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Movie>(movie.Id);
                loaded.Should().BeEquivalentTo(movie, c => c.IgnoringCyclicReferences());
            }
        }


        [Test]
        [Category("Integrationtests")]
        public void Delete_Movie_should_not_delete_Actors()
        {
            var movie = new Movie();
            var actor = new Person();
            movie.Actors.Add(actor);

            using (var con = new EfContext())
            {
                con.Add(movie);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Movie>(movie.Id);
                loaded.Should().BeEquivalentTo(movie, c => c.IgnoringCyclicReferences());
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loadedMovie = con.Find<Movie>(movie.Id);
                loadedMovie.Should().BeNull();

                var loadedActor = con.Find<Person>(actor.Id);
                actor.Should().NotBeNull();
            }
        }

        [Test]
        [Category("Integrationtests")]
        public void Delete_Actor_should_not_delete_Movie()
        {
            //nutzlos m:n macht eh keine cascadierung
        }

        [Test]
        [Category("Integrationtests")]
        public void Delete_Movie_should_not_delete_Directors()
        {
            //nutzlos m:n macht eh keine cascadierung
        }

        [Test]
        [Category("Integrationtests")]
        public void Delete_Directors_should_not_delete_Movie()
        {
            //nutzlos m:n macht eh keine cascadierung
        }

        [Test]
        [Category("Integrationtests")]
        public void Delete_Movie_should_set_Debutant_to_NULL()
        {
            var movie = new Movie();
            var debutant = new Person();
            movie.Debutants.Add(debutant);

            using (var con = new EfContext())
            {
                con.Add(movie);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Movie>(movie.Id);
                loaded.Should().BeEquivalentTo(movie, c => c.IgnoringCyclicReferences());
                var loadedDebutant = con.Find<Person>(debutant.Id);
                loadedDebutant.Debut.Should().NotBeNull();
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loadedMovie = con.Find<Movie>(movie.Id);
                loadedMovie.Should().BeNull();

                var loadedDebutant = con.Find<Person>(debutant.Id);
                loadedDebutant.Should().NotBeNull();
                loadedDebutant.Debut.Should().BeNull();
            }
        }

        [Test]
        [Category("Integrationtests")]
        public void Delete_Debutant_should_not_delete_Movie()
        {
            var movie = new Movie();
            var debutant = new Person();
            movie.Debutants.Add(debutant);

            using (var con = new EfContext())
            {
                con.Add(movie);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Movie>(movie.Id);
                loaded.Should().BeEquivalentTo(movie, c => c.IgnoringCyclicReferences());
                var loadedDebutant = con.Find<Person>(debutant.Id);
                loadedDebutant.Debut.Should().NotBeNull();
                con.Remove(loadedDebutant);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loadedMovie = con.Find<Movie>(movie.Id);
                loadedMovie.Should().NotBeNull();
                loadedMovie.Debutants.Should().BeEmpty();

                var loadedDebutant = con.Find<Person>(debutant.Id);
                loadedDebutant.Should().BeNull();
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}