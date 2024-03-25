using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<LocationModel>> GetAll();
        Task<LocationModel> GetById(int id);
        Task<LocationModel> FindByUserId(int id);
        Task<LocationModel> Add(LocationModel location);
        Task<LocationModel> Update(LocationModel location, int id);        
        Task<bool> Delete(int id);
        Task<bool> FindActiveLocationByMotorCycleId(int id);
    }
}
