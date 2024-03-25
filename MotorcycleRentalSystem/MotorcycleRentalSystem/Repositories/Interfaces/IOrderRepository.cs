using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAll();
        Task<OrderModel> GetById(int id);
        Task<OrderModel> Add(OrderModel order);
        Task<OrderModel> Update(OrderModel order, int id, int userId);
        Task<bool> Delete(int id);
    }
}
