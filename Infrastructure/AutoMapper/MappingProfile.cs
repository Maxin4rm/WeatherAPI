using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using WeatherApp.Server.DTO.RequestDTO;
using WeatherApp.Server.DTO.ResponseDto;
using WeatherApp.Server.Models;

namespace WeatherApp.Server.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Geolocation, GeolocationResponseDTO>();
            CreateMap<GeolocationRequestDTO, Geolocation>();
        }
    }
}
