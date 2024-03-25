using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Data;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;
using System.Linq;

namespace MotorcycleRentalSystem.Repositories
{
    public class MotorCycleRepository : IMotorCycleRepository
    {
        private readonly MotorcycleRentalDBContext _dbContext;
        public MotorCycleRepository(MotorcycleRentalDBContext context)
        {
            _dbContext = context;
        }
        public async Task<List<MotorCycleModel>> GetAll()
        {
            return await _dbContext.MotorCycle.ToListAsync();
        }
        public async Task<MotorCycleModel> GetById(int id) 
        {
            return await _dbContext.MotorCycle.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<MotorCycleModel> GetByPlate(string plateNumber)
        {
            return await _dbContext.MotorCycle.FirstOrDefaultAsync(x => x.plate == plateNumber);
        }
        public async Task<MotorCycleModel> Add(MotorCycleModel motorCycle)
        {
            await _dbContext.MotorCycle.AddAsync(motorCycle);
            await _dbContext.SaveChangesAsync();

            return motorCycle;
        }
        public async Task<MotorCycleModel> Update(MotorCycleModel motorCycle, int id)
        {
            MotorCycleModel dbMotorCycle = await GetById(id);
            if (motorCycle == null)
            {
                throw new Exception($"MotoCycle ID: {id} was not found in the database.");
            }

            _dbContext.MotorCycle.Update(dbMotorCycle);
            await _dbContext.SaveChangesAsync();

            return dbMotorCycle;
        }
        public async Task<MotorCycleModel> UpdateMotocyclePlate(MotorCycleModel motorCycle, string number)
        {
            MotorCycleModel dbMotorCycle = await GetByPlate(number);
            if (motorCycle == null)
            {
                throw new Exception($"MotoCycle Plate: {number} was not found in the database.");
            }

            _dbContext.MotorCycle.Update(dbMotorCycle);
            await _dbContext.SaveChangesAsync();

            return dbMotorCycle;
        }
        public async Task<bool> Delete(int id)
        {
            MotorCycleModel dbMotorCycle = await GetById(id);
            if (dbMotorCycle == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }

            _dbContext.MotorCycle.Remove(dbMotorCycle);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
