using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;
using System.Numerics;

namespace MotorcycleRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMotorCycleRepository _motorCycleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IPlanRepository _planRepository;
        public LocationController(IMotorCycleRepository motorCycleRepository, 
            IUserRepository userRepository, 
            ILocationRepository locationRepository, 
            IPlanRepository planRepository)
        {
            _motorCycleRepository = motorCycleRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _planRepository = planRepository;
        }
        public ActionResult<List<LocationModel>> GetAll()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<LocationModel>> Add([FromBody] LocationModel locationModel, int userId)
        {
            UserModel user = await _userRepository.GetById(userId);
            if (user != null)
            {
                if (await _userRepository.IsAdmin(userId))
                {
                    throw new Exception("administrator can only register motorcycles");
                }

                PlanModel plan = await _planRepository.GetById(locationModel.planId);
                if (plan == null)
                {
                    throw new Exception("this plan does not exist");
                }

                locationModel.startDate = DateTime.Now.AddDays(1);
                locationModel.endDate = DateTime.Now.AddDays(Convert.ToInt32(plan.periodType) + 1);
                locationModel.totalLocationValue = locationModel.expectedEndDate == locationModel.endDate ? Convert.ToInt32(plan.periodType) * plan.periodValue
                    : locationModel.endDate > locationModel.expectedEndDate ? Fine(locationModel.expectedEndDate, locationModel.endDate, plan)
                    : (Convert.ToInt32(plan.periodType) * plan.periodValue) + FineForNonDelivery(locationModel.expectedEndDate, locationModel.endDate);
            }            

            return Ok(locationModel);           

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] LocationModel locationModel, int id)
        {
            locationModel.Id = id;

            PlanModel plan = await _planRepository.GetById(locationModel.planId);
            if (plan == null)
            {
                throw new Exception("this plan does not exist");
            }

            locationModel.totalLocationValue = locationModel.expectedEndDate == locationModel.endDate ? Convert.ToInt32(plan.periodType) * plan.periodValue
                    : locationModel.endDate > locationModel.expectedEndDate ? Fine(locationModel.expectedEndDate, locationModel.endDate, plan)
                    : (Convert.ToInt32(plan.periodType) * plan.periodValue) + FineForNonDelivery(locationModel.expectedEndDate, locationModel.endDate);

            LocationModel location = await _locationRepository.Update(locationModel, id);
            return Ok(location);
        }
        public double Fine(DateTime expectedDate, DateTime endDate, PlanModel plan)
        {
            TimeSpan dif = endDate - expectedDate;
            int days = (int)dif.TotalDays;
            double valueOfNotUseDays = days * plan.periodValue;
            return valueOfNotUseDays * ( plan.ticketValue );
        }
        public double FineForNonDelivery(DateTime expectedDate, DateTime endDate)
        {
            TimeSpan dif = endDate - expectedDate;
            int days = (int)dif.TotalDays;
            double valueOfNotUseDays = days * 50.0;
            return valueOfNotUseDays;
        }
    }
}
