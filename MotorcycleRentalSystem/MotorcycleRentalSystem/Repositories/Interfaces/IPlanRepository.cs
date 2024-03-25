using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<List<PlanModel>> GetAll();
        Task<PlanModel> GetById(int id);
        Task<PlanModel> Add(PlanModel plan);
        Task<PlanModel> Update(PlanModel plan, int id);
        Task<bool> Delete(int id);
    }
}
