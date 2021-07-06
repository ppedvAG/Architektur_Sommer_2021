using System;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.UI.ASP_Blazor.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        static Random ran = new Random();
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = ran.Next(-20, 55),
                Summary = Summaries[ran.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
