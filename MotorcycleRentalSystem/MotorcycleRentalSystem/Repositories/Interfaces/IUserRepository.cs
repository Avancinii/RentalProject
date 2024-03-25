using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task<bool> CnpjAlredyExist(string cnpj);
        Task<bool> CnhAlredyExist(string cnpj);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id, byte[] image);
        Task<bool> Delete(int id);
        Task<bool> IsAdmin(int id);
    }
}
