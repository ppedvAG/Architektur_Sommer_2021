using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.Logic.Services
{
    public class MovieThemePlayerService : IMovieThemePlayerService
    {
        public IDevice PlayerDevice { get; }

        public MovieThemePlayerService(IDevice playerDevice)
        {
            PlayerDevice = playerDevice;
        }

        public void PlayTheme(Movie movie)
        {
            foreach (string line in movie.SoundTheme.Split(Environment.NewLine))
            {
                var chunks = line.Split(",");
                PlayerDevice.Play(int.Parse(chunks[0]), int.Parse(chunks[1]));
            }
        }
    }
}
