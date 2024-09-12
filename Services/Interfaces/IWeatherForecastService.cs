using WeatherApp.Server.Models;

namespace WeatherApp.Server.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        public Task<Weather> GetWeatherAsync();
    }
}
