using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using WeatherApp.Server.DTO.ResponseDto;
using WeatherApp.Server.Models;
using WeatherApp.Server.Repositories.Interfaces;
using WeatherApp.Server.Services.Interfaces;

namespace WeatherApp.Server.Services.Implementations
{
    public class WeatherForecastService(ILocationRepository locationRepository, HttpClient httpClient) : IWeatherForecastService
    {
        private const string apiKey = "626dd3d731acaff0ff391c86f0cabb70";
        private const string apiUrl = "http://api.openweathermap.org/data/2.5/weather";
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILocationRepository _locationRepository = locationRepository;

        public async Task<Weather> GetWeatherAsync()
        {
            var location = await _locationRepository.GetAsync();
            var requestUrl = $"{apiUrl}?lat={location.Latitude}&lon={location.Longitude}&appid={apiKey}";
            var response = await _httpClient.GetAsync(requestUrl);
            var weatherData = await response.Content.ReadAsStringAsync();
            Weather weather = new();
            try
            {
                weather.Temp = GetValue(ref weatherData, "temp");
                weather.FeelsLike = GetValue(ref weatherData, "feels_like");
                weather.Pressure = GetValue(ref weatherData, "pressure");
                weather.Humidity = GetValue(ref weatherData, "humidity");
            }
            catch (Exception) { }
            return weather;
        }

        private static string GetValue(ref string source, string key)
        {
            var startIndex = source.IndexOf(key) + key.Length + 1;
            while (!source[startIndex].IsValueSymbol()) 
                startIndex++;
            int length = 0;
            while (source[startIndex + length].IsValueSymbol())
                length++;
            return source.Substring(startIndex, length);
        }
    }
}



/*
{"coord":{"lon":0,"lat":0},"weather":[{"id":802,"main":"Clouds","description":"scattered clouds","icon":"03n"}],"base":"stations",
"main":{"temp":297.72,"feels_like":298.35,"temp_min":297.72,"temp_max":297.72,"pressure":1013,"humidity":81,"sea_level":1013,"grnd_level":1013},
"visibility":10000,"wind":{"speed":3.59,"deg":201,"gust":3.72},"clouds":{"all":38},"dt":1725600188,"sys":{"sunrise":1725602107,"sunset":1725645708},
"timezone":0,"id":6295630,"name":"Globe","cod":200}
*/