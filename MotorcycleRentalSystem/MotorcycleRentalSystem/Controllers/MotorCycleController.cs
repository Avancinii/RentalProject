using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;

namespace MotorcycleRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorCycleController : ControllerBase
    {
        private readonly IMotorCycleRepository _motorCycleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        public MotorCycleController(IMotorCycleRepository motorCycleRepository, IUserRepository userRepository, ILocationRepository locationRepository)
        {
            _motorCycleRepository = motorCycleRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<MotorCycleModel>>> GetAll()
        {
            List<MotorCycleModel> motorCycles = await _motorCycleRepository.GetAll();
            return Ok(motorCycles);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MotorCycleModel>> GetById(int id)
        {
            MotorCycleModel motorCycle = await _motorCycleRepository.GetById(id);
            return Ok(motorCycle);
        }
        [HttpGet("plate/{number}")]
        public async Task<ActionResult<MotorCycleModel>> GetByPlate(string number)
        {
            MotorCycleModel motorCycle = await _motorCycleRepository.GetByPlate(number);            
            return Ok(motorCycle);
        }
        [HttpPost]
        public async Task<ActionResult<MotorCycleModel>> Add([FromBody] MotorCycleModel motorCyclesModel, int userId)
        {
            if (! await _userRepository.IsAdmin(userId))
            {
                throw new Exception("Only administrator can register a motorcycles");
            }
            else
            {
                MotorCycleModel motorCycle = await _motorCycleRepository.GetByPlate(motorCyclesModel.plate);
                if (motorCycle != null)
                {
                    throw new Exception($"There is already a motorcycle with the license plate {motorCyclesModel.plate} registered");
                }
                else {
                    MotorCycleModel result = await _motorCycleRepository.Add(motorCyclesModel);
                    return Ok(result);
                }                
            }
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<MotorCycleModel>> Update([FromBody] MotorCycleModel motorCyclesModel, int id)
        {
            motorCyclesModel.Id = id;
            MotorCycleModel motorCycles = await _motorCycleRepository.Update(motorCyclesModel, id);
            return Ok(motorCycles);
        }
        [HttpPut("plate/{number}")]
        public async Task<ActionResult<MotorCycleModel>> UpdateMotocyclePlate(MotorCycleModel motorCycleModel, string number, int userId)
        {
            if (!await _userRepository.IsAdmin(userId))
            {
                throw new Exception("Only the administrator can change the license plate of a motorcycle");
            }
            else
            {
                MotorCycleModel motorCycles = await _motorCycleRepository.UpdateMotocyclePlate(motorCycleModel, number);
                motorCycleModel.plate = number;
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MotorCycleModel>> Delete(int id,int userId)
        {
            if(! await _locationRepository.FindActiveLocationByMotorCycleId(id) && !await _userRepository.IsAdmin(userId))
            {
                throw new Exception("Only the adminstrator can dele a motorcycle");
            }
            else
            {
                bool result = await _motorCycleRepository.Delete(id);
                return Ok(result);
            }            
        }
    }
}
