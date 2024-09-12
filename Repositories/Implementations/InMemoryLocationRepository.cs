using Microsoft.AspNetCore.Components.Forms;
using WeatherApp.Server.Models;
using WeatherApp.Server.Repositories.Interfaces;

namespace WeatherApp.Server.Repositories.Implementations
{
    public class InMemoryLocationRepository : ILocationRepository
    {
        private Geolocation _location = new();
        public async Task<Geolocation> GetAsync()
        {
            Geolocation location = new();
            await Task.Run(() =>
            {
                location = _location;
            });
            return location;
        }

        public async Task<Geolocation> CreateAsync(Geolocation location)
        {
            await Task.Run(() =>
            {
                _location = location;
            });
            return location;
        }
    }
}
