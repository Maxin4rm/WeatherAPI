using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Server.DTO.RequestDTO;
using WeatherApp.Server.Models;
using WeatherApp.Server.Services.Implementations;
using WeatherApp.Server.Services.Interfaces;

namespace WeatherApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeolocationController(ILogger<GeolocationController> logger, IGeolocationService geolocationService) : ControllerBase
    {
        private readonly ILogger<GeolocationController> _logger = logger;
        private readonly IGeolocationService _geolocationService = geolocationService;

        [HttpPost]
        public async Task<IActionResult> CreateGeolocation([FromBody] GeolocationRequestDTO location)
        {
            var createdGeolocation = await _geolocationService.CreateGeolocationAsync(location);
            return Ok(createdGeolocation);
        }
    }
}
