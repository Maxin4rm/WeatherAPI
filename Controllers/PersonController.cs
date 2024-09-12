using Microsoft.AspNetCore.Mvc;
using WeatherApp.Server.DTO.RequestDTO;
using WeatherApp.Server.Models;
using WeatherApp.Server.Repositories.Interfaces;
using WeatherApp.Server.Services.Implementations;
using WeatherApp.Server.Services.Interfaces;

namespace WeatherApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController(IPersonRepository personRepository) : ControllerBase
    {
        
        private readonly IPersonRepository _personRepository = personRepository;

        [HttpGet]
        public Task<IEnumerable<Person>> GetPersons()
        {
            return personRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Createperson([FromBody] Person person)
        {
            var createdPerson = await _personRepository.CreateAsync(person);
            return Ok(createdPerson);
        }
    }
}
