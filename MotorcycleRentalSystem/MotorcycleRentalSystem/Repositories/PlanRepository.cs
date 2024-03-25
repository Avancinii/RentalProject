using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Data;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;

namespace MotorcycleRentalSystem.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly MotorcycleRentalDBContext _dbContext;
        public PlanRepository(MotorcycleRentalDBContext context)
        {
            _dbContext = context;
        }
        public async Task<List<PlanModel>> GetAll()
        {
            return await _dbContext.Plan.ToListAsync();
        }
        public async Task<PlanModel> GetById(int id)
        {
            return await _dbContext.Plan.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<PlanModel> Add(PlanModel plan)
        {
            await _dbContext.Plan.AddAsync(plan);
            await _dbContext.SaveChangesAsync();

            return plan;
        }
        public async Task<PlanModel> Update(PlanModel plan, int id)
        {
            PlanModel dbPlan = await GetById(id);
            if (dbPlan == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }

            _dbContext.Plan.Update(dbPlan);
            await _dbContext.SaveChangesAsync();

            return dbPlan;
        }        
        public async Task<bool> Delete(int id)
        {
            PlanModel dbPlan = await GetById(id);
            if (dbPlan == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }

            _dbContext.Plan.Remove(dbPlan);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
