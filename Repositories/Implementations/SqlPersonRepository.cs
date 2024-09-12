using Microsoft.EntityFrameworkCore;
using WeatherApp.Server.Data;
using WeatherApp.Server.Models;
using WeatherApp.Server.Repositories.Interfaces;

namespace WeatherApp.Server.Repositories.Implementations
{
    public class SqlPersonRepository : IPersonRepository
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<Person> _dbSet;

        public SqlPersonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Person>();
        }
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(long id)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(c => c.PersonId == id);
        }

        public async Task<Person> CreateAsync(Person entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Person> UpdateAsync(Person entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
