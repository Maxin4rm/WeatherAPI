using Microsoft.AspNetCore.Mvc;
using WeatherApp.Server.Services.Implementations;
using WeatherApp.Server.Services.Interfaces;

namespace WeatherApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService) : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger = logger;
        private readonly IWeatherForecastService _weatherForecastService = weatherForecastService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var weatherData = await _weatherForecastService.GetWeatherAsync();
            return Ok(weatherData);
        }
    }
}
