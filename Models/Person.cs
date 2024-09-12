namespace WeatherApp.Server.Models
{
    public class Person
    {
        public long PersonId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
