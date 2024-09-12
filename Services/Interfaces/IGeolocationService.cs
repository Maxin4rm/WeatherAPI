using WeatherApp.Server.DTO.RequestDTO;
using WeatherApp.Server.DTO.ResponseDto;

namespace WeatherApp.Server.Services.Interfaces
{
    public interface IGeolocationService
    {
        public Task<GeolocationResponseDTO> GetGeolocationAsync();
        public  Task<GeolocationResponseDTO> CreateGeolocationAsync(GeolocationRequestDTO geolocation);
    }
}
