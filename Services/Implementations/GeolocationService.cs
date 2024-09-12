using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using WeatherApp.Server.DTO.RequestDTO;
using WeatherApp.Server.DTO.ResponseDto;
using WeatherApp.Server.Models;
using WeatherApp.Server.Repositories.Interfaces;
using WeatherApp.Server.Services.Interfaces;

namespace WeatherApp.Server.Services.Implementations
{
    public class GeolocationService(ILocationRepository locationRepository, IMapper mapper) : IGeolocationService
    {
        private readonly ILocationRepository _locationRepository = locationRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GeolocationResponseDTO> GetGeolocationAsync()
        {
            var location = await _locationRepository.GetAsync();
            return _mapper.Map<GeolocationResponseDTO>(location);
        }

        public async Task<GeolocationResponseDTO> CreateGeolocationAsync(GeolocationRequestDTO geolocation)
        {
            var geolocationToCreate = _mapper.Map<Geolocation>(geolocation);
            var createdGeolocation = await _locationRepository.CreateAsync(geolocationToCreate);
            return _mapper.Map<GeolocationResponseDTO>(createdGeolocation);
        }
    }
}
