using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Repositories.Interfaces
{
    public interface IMotorCycleRepository
    {
        Task<List<MotorCycleModel>> GetAll();
        Task<MotorCycleModel> GetById(int id);
        Task<MotorCycleModel> GetByPlate(string id);
        Task<MotorCycleModel> Add(MotorCycleModel motorCycle);
        Task<MotorCycleModel> Update(MotorCycleModel motorCycle, int id);
        Task<MotorCycleModel> UpdateMotocyclePlate(MotorCycleModel motorCycle, string number);
        Task<bool> Delete(int id);
    }
}
