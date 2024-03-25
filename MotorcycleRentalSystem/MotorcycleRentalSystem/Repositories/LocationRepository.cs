using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Data;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;

namespace MotorcycleRentalSystem.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MotorcycleRentalDBContext _dbContext;
        public LocationRepository(MotorcycleRentalDBContext context)
        {
            _dbContext = context;
        }
        public async Task<List<LocationModel>> GetAll()
        {
            return await _dbContext.Location.Include(x => x.User).ToListAsync();
        }

        public async Task<LocationModel> GetById(int id)
        {
            return await _dbContext.Location.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<LocationModel> Add(LocationModel location)
        {
            await _dbContext.Location.AddAsync(location);
            await _dbContext.SaveChangesAsync();

            return location;
        }
        public async Task<LocationModel> Update(LocationModel location, int id)
        {
            LocationModel dbLocation = await GetById(id);
            if (dbLocation == null)
            {
                throw new Exception($"Location ID: {id} was not found in the database.");
            }

            _dbContext.Location.Update(dbLocation);
            await _dbContext.SaveChangesAsync();

            return dbLocation;
        }
        public async Task<bool> Delete(int id)
        {
            LocationModel dbLocation = await GetById(id);
            if (dbLocation == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }

            _dbContext.Location.Remove(dbLocation);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> FindActiveLocationByMotorCycleId(int id)
        {
            LocationModel location = await _dbContext.Location.FirstOrDefaultAsync(x => x.motorCycleId == id && x.isActive == true);
            return location == null ? false : true;
        }

        public async Task<LocationModel> FindByUserId(int id)
        {
            return await _dbContext.Location.Include(x => x.User).FirstOrDefaultAsync(x => x.userId == id && x.isActive == true);
        }
    }
}
