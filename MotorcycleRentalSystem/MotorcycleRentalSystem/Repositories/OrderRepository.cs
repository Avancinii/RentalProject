using MotorcycleRentalSystem.Data;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;

namespace MotorcycleRentalSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MotorcycleRentalDBContext _dbContext;
        public OrderRepository(MotorcycleRentalDBContext context)
        {
            _dbContext = context;
        }
        public Task<OrderModel> Add(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> Update(OrderModel order, int id, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
