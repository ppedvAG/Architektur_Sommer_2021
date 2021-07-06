using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.MovieThemeCollector.Logic.Tests
{
    public class MoviesServiceTest
    {
        [Test]
        public void GetLatestMovie_no_movie_in_repo_returns_null()
        {
            var repo = A.Fake<IRepository<Movie>>();
            A.CallTo(() => repo.Query()).Returns(new List<Movie>().AsQueryable());
            
            var uow = A.Fake<IUnitOfWork>();
            A.CallTo(()=>uow.GetRepo<Movie>()).Returns(repo);

            var moviesService = new MoviesService(uow);

            var result = moviesService.GetLatestMovie();

            result.Should().BeNull();
        }

        [Test]
        public void GetLatestMovie_two_movie_in_repo_returns_m2()
        {
            var m1 = new Movie() { Title = "m1", Published = DateTime.Now.AddDays(-3) };
            var m2 = new Movie() { Title = "m2", Published = DateTime.Now.AddDays(-2) };
            var repo = A.Fake<IRepository<Movie>>();
            A.CallTo(() => repo.Query()).Returns(new[] { m1, m2 }.AsQueryable());
            var uow = A.Fake<IUnitOfWork>();
            A.CallTo(() => uow.GetRepo<Movie>()).Returns(repo);
            var moviesService= new MoviesService( uow);

            var result = moviesService.GetLatestMovie();

            result.Should().Be(m2);
        }

        [Test]
        public void GetLatestMovie_two_movie_with_same_date_in_repo_returns_m02()
        {
            var m1 = new Movie() { Title = "m1", Published = DateTime.Now };
            var m2 = new Movie() { Title = "m02", Published = DateTime.Now };
            var m3 = new Movie() { Title = "m3", Published = DateTime.Now };
            var repo = A.Fake<IRepository<Movie>>();
            A.CallTo(() => repo.Query()).Returns(new[] { m1, m2, m3 }.AsQueryable());
            var uow = A.Fake<IUnitOfWork>();
            A.CallTo(() => uow.GetRepo<Movie>()).Returns(repo);
            var moviesService = new MoviesService( uow);

            var result = moviesService.GetLatestMovie();

            result.Should().Be(m2);
        }
    }
}