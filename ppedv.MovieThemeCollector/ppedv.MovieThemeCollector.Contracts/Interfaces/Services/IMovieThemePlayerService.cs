using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.Contracts.Interfaces.Services
{
    public interface IMovieThemePlayerService
    {
        IDevice PlayerDevice { get; }

        void PlayTheme(Movie movie);
    }
}
