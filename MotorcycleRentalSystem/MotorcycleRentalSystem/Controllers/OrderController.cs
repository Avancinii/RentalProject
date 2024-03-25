using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories;
using MotorcycleRentalSystem.Repositories.Interfaces;

namespace MotorcycleRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILocationRepository _locationRepository;
        public OrderController(IUserRepository userRepository, IOrderRepository orderRepository, ILocationRepository locationRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetAll()
        {
            List<OrderModel> orders = await _orderRepository.GetAll();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetById(int id)
        {
            OrderModel order = await _orderRepository.GetById(id);
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<MotorCycleModel>> Add([FromBody] OrderModel order, int userId)
        {
            if (!await _userRepository.IsAdmin(userId))
            {
                throw new Exception("Only administrator can register a motorcycles");
            }
            else
            {
                order.Situation = Enuns.Situation.Disponivel;
                OrderModel result = await _orderRepository.Add(order);
                return Ok(result);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> AcceptOrderRequest([FromBody] OrderModel order,int id ,int userId)
        {
            order.Id = id;
            if (await _userRepository.IsAdmin(userId))
            {
                return BadRequest("Only delivery people can accept the order");
            }
            else
            {
                LocationModel location = await _locationRepository.FindByUserId(userId);
                if (location != null)
                {

                    OrderModel result = await _orderRepository.Update(order, id, userId);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("The delivery man does not have any motorcycle allocated");
                }
            }
            
            

            
        }
    }
}
