using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Logic;
using ppedv.MovieThemeCollector.Logic.Services;
using ppedv.MovieThemeCollector.UI.ASP_WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.MovieThemeCollector.UI.ASP_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        MoviesService moviesService;
        MapperConfiguration mapperConfiguration;

        public MoviesController(IUnitOfWork uow)
        {
            moviesService = new MoviesService(uow);

            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>()
                   .ForMember(m => m.PubDate, dto => dto.MapFrom(x => x.Published))
                   .ReverseMap();
                cfg.CreateMap<Person, PersonDTO>().ReverseMap();
            });
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<MovieDTO> Get()
        {
            var movies = moviesService.UnitOfWork.MovieRepository.Query().ToList();
            var mapper = mapperConfiguration.CreateMapper();

            foreach (var m in movies)
            {
                yield return mapper.Map<MovieDTO>(m);
            }
        }


        private IEnumerable<MovieDTO> GetMitYield_OhneAutoMapper()
        {
            var movies = moviesService.UnitOfWork.MovieRepository.Query().ToList();

            foreach (var m in movies)
            {
                yield return new MovieDTO()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Length = m.Length,
                    PubDate = m.Published
                };
            }
        }

        private IEnumerable<MovieDTO> GetOhneYield()
        {
            var movies = moviesService.UnitOfWork.MovieRepository.Query().ToList();

            List<MovieDTO> movieDTOs = new List<MovieDTO>();
            foreach (var m in movies)
            {
                movieDTOs.Add(new MovieDTO());
            }
            return movieDTOs;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public MovieDTO Get(int id)
        {
            return mapperConfiguration.CreateMapper().Map<MovieDTO>(moviesService.UnitOfWork.MovieRepository.GetById(id));
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] MovieDTO value)
        {
            var movie = mapperConfiguration.CreateMapper().Map<Movie>(value);
            moviesService.UnitOfWork.MovieRepository.Add(movie);
            moviesService.UnitOfWork.Save();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MovieDTO value)
        {
            var movie = mapperConfiguration.CreateMapper().Map<Movie>(value);
            moviesService.UnitOfWork.MovieRepository.Update(movie);
            moviesService.UnitOfWork.Save();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            moviesService.UnitOfWork.MovieRepository.DeleteById(id);
            moviesService.UnitOfWork.Save();
        }
    }
}
