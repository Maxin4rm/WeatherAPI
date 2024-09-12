using WeatherApp.Server.Models;

namespace WeatherApp.Server.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        public Task<IEnumerable<Person>> GetAllAsync();

        public Task<Person?> GetByIdAsync(long id);

        public Task<Person> CreateAsync(Person entity);

        public Task<Person> UpdateAsync(Person entity);

        public Task<bool> DeleteAsync(long id);
    }
}
