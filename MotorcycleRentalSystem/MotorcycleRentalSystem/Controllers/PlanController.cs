using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        public ActionResult<List<PlanModel>> GetAll()
        {
            return Ok();
        }
    }
}
