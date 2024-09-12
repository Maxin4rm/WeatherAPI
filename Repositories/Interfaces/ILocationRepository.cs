using WeatherApp.Server.Models;

namespace WeatherApp.Server.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        public Task<Geolocation> GetAsync();
        public Task<Geolocation> CreateAsync(Geolocation location);
    }
}
